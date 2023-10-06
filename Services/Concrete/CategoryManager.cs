using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public CategoryManager(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}
		public Category GetOneCategory(int id, bool trackChanges)
		{
			var category = _repositoryManager.Category.GetOneCategory(id, trackChanges);
			if (category == null)
				throw new Exception("Category not found!");
			return category;
		}
		public IEnumerable<Category> GetAllCategories(bool trackChanges)
		{
			return _repositoryManager.Category.GetAllCategories(trackChanges);
		}
		public void CreateCategory(CategoryDtoForCreation categoryDto)
		{
			var category = _mapper.Map<Category>(categoryDto);
			_repositoryManager.Category.CreateCategory(category);
			_repositoryManager.Save();
		}

		public void DeleteOneCategory(int id)
		{
			var category = GetOneCategory(id,false);
			_repositoryManager.Category.DeleteOneCategory(category);
			_repositoryManager.Save();
		}
	}
}
