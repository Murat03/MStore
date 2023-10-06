using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
	{
		private readonly IServiceManager _manager;

		public CategoryController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			return View(_manager.CategoryService.GetAllCategories(false));
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create([FromForm(Name ="categoryname")] string categoryname)
		{
			if(categoryname == null)
				return RedirectToAction("Index");
			_manager.CategoryService.CreateCategory(new CategoryDtoForCreation() { CategoryName= categoryname});
			TempData["success"] = "The category has been created.";
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Delete([FromRoute(Name = "id")] int id)
		{
			_manager.CategoryService.DeleteOneCategory(id);
			TempData["danger"] = "The category has been removed.";
			return RedirectToAction("Index");
		}
	}
}
