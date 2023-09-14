using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IProductService
	{
		IEnumerable<Product> GetAllProducts(bool trackChanges);
		IEnumerable<Product> GetShowcaseProducts(bool trackChanges);
		IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
		void CreateProduct(ProductDtoForInsertion productDto);
		void DeleteOneProduct(int id);
		Product GetOneProduct(int id, bool trackChanges);
		ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
		void UpdateOneProduct(ProductDtoForUpdate productDto);
	}
}
