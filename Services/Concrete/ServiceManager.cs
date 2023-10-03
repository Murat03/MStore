using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
	public class ServiceManager : IServiceManager
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IOrderService _orderService;
		private readonly IAuthService _authService;
		private readonly IRoleService _roleService;

		public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService, IAuthService authService, IRoleService roleService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_orderService = orderService;
			_authService = authService;
			_roleService = roleService;
		}

		public IProductService ProductService => _productService;

		public ICategoryService CategoryService => _categoryService;

		public IOrderService OrderService => _orderService;

		public IAuthService AuthService => _authService;

		public IRoleService RoleService => _roleService;
	}
}
