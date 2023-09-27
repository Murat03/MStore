using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IAuthService
	{
		IEnumerable<IdentityRole> Roles { get; }
		IEnumerable<ApplicationUser> GetAllUsers();
		Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
		Task<ApplicationUser> GetOneUser(string userName);
		Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
		Task UpdateOneUser(UserDtoForUpdate userDto);
		Task<IdentityResult> ResetPassword(ResetPasswordDto model);
		Task<IdentityResult> DeleteOneUser(string userName);
	}
}
