using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete
{
	public class RepositoryManager : IRepositoryManager
	{
		public readonly RepositoryContext _context;
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;
		public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
			_context = context;
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}

		public IProductRepository Product => _productRepository;
		public ICategoryRepository Category => _categoryRepository;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
