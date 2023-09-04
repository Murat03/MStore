﻿using Entities.Models;
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
		Product? GetOneProduct(int id, bool trackChanges);
	}
}
