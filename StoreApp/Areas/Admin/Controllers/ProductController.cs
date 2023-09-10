using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IServiceManager _manager;
		public ProductController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var model = _manager.ProductService.GetAllProducts(false);
			return View(model);
		}
		public IActionResult Create()
		{
			ViewBag.Categories = GetCategoriesSelectList();
			return View();
		}
		private SelectList GetCategoriesSelectList()
		{
			return new SelectList(_manager.CategoryService.GetAllCategories(false),
				"CategoryId", "CategoryName", "1");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm]ProductDtoForInsertion productDto, IFormFile file)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

			using (var stream = new FileStream(path, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			productDto.ImageUrl = String.Concat("/images/", file.FileName);
			_manager.ProductService.CreateProduct(productDto);
			return RedirectToAction("Index");
		}
		public IActionResult Update([FromRoute(Name = "id")] int id)
		{
			ViewBag.Categories = GetCategoriesSelectList();
			var model = _manager.ProductService.GetOneProductForUpdate(id, false);
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([FromForm]ProductDtoForUpdate productDto, IFormFile file)
		{
			if (ModelState.IsValid)
			{
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName); // a/b/c

				using (var stream = new FileStream(path, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				productDto.ImageUrl = String.Concat("/images/", file.FileName);
				_manager.ProductService.UpdateOneProduct(productDto);
				return RedirectToAction("Index");
			}
			
			return View();
		}
		[HttpGet]
		public IActionResult Delete([FromRoute(Name ="id")]int id)
		{
			_manager.ProductService.DeleteOneProduct(id);
			TempData["danger"] = "The product has been removed.";
			return RedirectToAction("Index");
		}
	}
}
