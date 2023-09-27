using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Concrete;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
	public class ProductController : Controller
	{
		private readonly IServiceManager _manager;
		public ProductController(IServiceManager manager)
		{
			_manager = manager;
		}
		public IActionResult Index(ProductRequestParameters p)
		{
			ViewBag.Title = "Product";
			var products = _manager.ProductService.GetAllProductsWithDetails(p);
			var pagination = new Pagination()
			{
				CurrentPage = p.PageNumber,
				ItemsPerPage = p.PageSize,
				TotalItems = _manager.ProductService.GetAllProducts(false).Count()
			};
			return View(new ProductListViewModel()
			{
				Products = products,
				Pagination = pagination
			});
		}
		public IActionResult Get(int id)
		{
			var product = _manager.ProductService.GetOneProduct(id, false);
			ViewData["Title"] = product?.ProductName;
			return View(product);
		}
	}
}
