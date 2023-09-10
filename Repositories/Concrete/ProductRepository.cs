using Entities.DataTransferObjects;
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

		public void CreateProduct(Product product)
		{
			Create(product);
		}

		public void DeleteOneProduct(Product product)
		{
			Remove(product);
		}

		public IQueryable<Product> GetAllProducts(bool trackChanges)
		{
			return FindAll(false);
		}

		public Product? GetOneProduct(int id, bool trackChanges)
		{
			return FindByCondition(p => p.ProductId.Equals(id) ,trackChanges);
		}

		public void UpdateOneProduct(Product product)
		{
			Update(product);
		}
	}
}
