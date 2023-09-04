﻿using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete
{
	public class CategoryRepository : RepositoryBase<Category> ,ICategoryRepository
	{
		public CategoryRepository(RepositoryContext context) : base(context)
		{
		}

		public IQueryable<Category> GetAllCategories(bool trackChanges)
		{
			return FindAll(trackChanges);
		}

		public Category? GetOneCategory(int id, bool trackChanges)
		{
			return FindByCondition(c => c.Id.Equals(id), trackChanges);
		}
	}
}