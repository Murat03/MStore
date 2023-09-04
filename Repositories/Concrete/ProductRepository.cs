using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(RepositoryContext context) : base(context)
		{
		}

		public IQueryable<Product> GetAllProducts(bool trackChanges)
		{
			return FindAll(false);
		}

		public Product? GetOneProduct(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id) ,trackChanges);
		}
	}
}
