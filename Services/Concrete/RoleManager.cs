using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
	public class RoleManager : IRoleService
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		public RoleManager(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}
		public async Task<IdentityResult> CreateRole(IdentityRole role)
		{
			return await _roleManager.CreateAsync(role);
		}

		public async Task<IdentityResult> DeleteOneRole(string id)
		{
			var role = await _roleManager.FindByNameAsync(id);
			if (role == null)
				throw new Exception("The role could not found!");
			var result = await _roleManager.DeleteAsync(role);
			return result;
		}
	}
}
