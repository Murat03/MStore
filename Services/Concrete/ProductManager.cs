using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IRepositoryManager _manager;
		private readonly IMapper _mapper;
		public ProductManager(IRepositoryManager manager, IMapper mapper)
		{
			_manager = manager;
			_mapper = mapper;
		}
		public IEnumerable<Product> GetAllProducts(bool trackChanges)
		{
			return _manager.Product.GetAllProducts(trackChanges);
		}
		public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
		{
			return _manager.Product.GetAllProductsWithDetails(p);
		}
		public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
		{
			var products = _manager.Product.GetShowcaseProducts(trackChanges);
			return products;
		}
		public IEnumerable<Product> GetLastestProducts(int number, bool trackChanges)
		{
			return _manager.Product.GetAllProducts(trackChanges)
				.OrderByDescending(prd => prd.ProductId)
				.Take(number);
		}
		public Product GetOneProduct(int id, bool trackChanges)
		{
			var product = _manager.Product.GetOneProduct(id, trackChanges);
			if (product == null)
			{
				throw new Exception("Product not found!");
			}
			return product;
		}

		public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
		{
			var product = GetOneProduct(id, trackChanges);
			var productDto = _mapper.Map<ProductDtoForUpdate>(product);
			return productDto;
		}

		public void CreateProduct(ProductDtoForInsertion productDto)
		{
			Product product = _mapper.Map<Product>(productDto);
			_manager.Product.CreateProduct(product);
			_manager.Save();
		}

		public void DeleteOneProduct(int id)
		{
			var product = GetOneProduct(id, false);
			_manager.Product.DeleteOneProduct(product);
			_manager.Save();
		}
		public void UpdateOneProduct(ProductDtoForUpdate productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			_manager.Product.UpdateOneProduct(product);
			_manager.Save();
		}

		
	}
}
