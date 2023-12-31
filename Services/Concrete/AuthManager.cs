﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
	public class AuthManager : IAuthService
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;
		public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMapper mapper)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_mapper = mapper;
		}

		public IEnumerable<IdentityRole> Roles => _roleManager.Roles;
		public IEnumerable<ApplicationUser> GetAllUsers()
		{
			return _userManager.Users.ToList();
		}
		public async Task<ApplicationUser> GetOneUser(string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user is null)
				throw new Exception("User could not be found.");
			return user;
		}
		public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
		{
			var user = await GetOneUser(userName);
			var userDto = _mapper.Map<UserDtoForUpdate>(user);
			
			userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
			userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));

			return userDto;
		}
		public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
		{
			var user = _mapper.Map<ApplicationUser>(userDto);
			var result = await _userManager.CreateAsync(user, userDto.Password);
			if (!result.Succeeded)
				throw new Exception("User could not be created.");

			if (userDto.Roles.Count > 0)
			{
				var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
				if (!roleResult.Succeeded)
					throw new Exception("System have problems with roles.");

			}
			return result;
		}
		public async Task UpdateOneUser(UserDtoForUpdate userDto)
		{
			var user = await GetOneUser(userDto.UserName);
			user.PhoneNumber = userDto.PhoneNumber;
			user.Email = userDto.Email;
			var result = await _userManager.UpdateAsync(user);
			if(userDto.Roles.Count > 0)
			{
				var userRoles = await _userManager.GetRolesAsync(user);
				var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles);
				var r2 = await _userManager.AddToRolesAsync(user, userDto.Roles);
			}
			return;
		}
		public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
		{
			var user = await GetOneUser(model.UserName);
			await _userManager.RemovePasswordAsync(user);
			var result = await _userManager.AddPasswordAsync(user,model.Password);
			return result;
		}

		public async Task<IdentityResult> DeleteOneUser(string userName)
		{
			var appUser = await GetOneUser(userName);
			var result = await _userManager.DeleteAsync(appUser);
			return result;
		}
	}
}
