using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IProductService
	{
		void CreateProduct(ProductDtoForInsertion productDto);
		void DeleteOneProduct(int id);
		IEnumerable<Product> GetAllProducts(bool trackChanges);
		Product GetOneProduct(int id, bool trackChanges);
		ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
		void UpdateOneProduct(ProductDtoForUpdate productDto);
	}
}
