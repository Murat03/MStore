using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Data;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class RoleController : Controller
	{
		private readonly IServiceManager _manager;

		public RoleController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			return View(_manager.AuthService.Roles);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm(Name ="rolename")] string rolename)
		{
			if (rolename == null)
				return RedirectToAction("Index");

			await _manager.RoleService.CreateRole(new IdentityRole() { Name=rolename, NormalizedName=rolename.ToUpper()});
			TempData["success"] = $"{rolename} has been created.";
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete([FromRoute(Name = "id")] string id)
		{
			var result = await _manager.RoleService.DeleteOneRole(id);
			TempData["danger"] = "The role has been removed.";
			return RedirectToAction("Index");
		}
	}
}
