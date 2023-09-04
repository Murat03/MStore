﻿using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> 
		where T : class, new()
	{
		private readonly RepositoryContext _context;

		public RepositoryBase(RepositoryContext context)
		{
			_context = context;
		}
        public IQueryable<T> FindAll(bool trackChanges)
		{
			return trackChanges ? _context.Set<T>()
				: _context.Set<T>().AsNoTracking();
		}

		public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
		{
			return trackChanges ? _context.Set<T>().Where(expression).SingleOrDefault()
				: _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
		}
	}
}