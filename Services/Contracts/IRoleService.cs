using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IRoleService
	{
		public Task<IdentityResult> CreateRole(IdentityRole role);
		Task<IdentityResult> DeleteOneRole(string id);
	}
}
