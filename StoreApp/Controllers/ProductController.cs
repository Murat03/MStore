using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

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
			IEnumerable<Product> products = _manager.ProductService.GetAllProductsWithDetails(p);
			return View(products);
		}
		public IActionResult Get(int id)
		{
			var product = _manager.ProductService.GetOneProduct(id, false);
			return View(product);
		}
	}
}
