﻿using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface ICategoryService
	{
		public IEnumerable<Category> GetAllCategories(bool trackChanges);
		public void CreateCategory(CategoryDtoForCreation categoryDto);
		public void DeleteOneCategory(int id);
	}
}
