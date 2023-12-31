﻿using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
	public interface IProductRepository
	{
		IQueryable<Product> GetAllProducts(bool trackChanges);
		IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
		IQueryable<Product> GetShowcaseProducts(bool trackChanges);
		void CreateProduct(Product product);
		void DeleteOneProduct(Product product);
		
		Product? GetOneProduct(int id, bool trackChanges);
		void UpdateOneProduct(Product product);
	}
}
