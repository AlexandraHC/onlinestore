using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Persistence.Entities;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Add(CategoryModel model)
        {
            var categoryEntity = new Category
            {
                CategoryName = model.Name,
                CategoryDescription = model.Description
            };

            await _categoryRepository.AddAsync(categoryEntity);
        }

        public async Task<IEnumerable<CategoryModel>> GetAll()
        {
            var allCategories = await _categoryRepository.GetAllAsync();

            var modelsList = new List<CategoryModel>();
            foreach (var entity in allCategories)
            {
                var model = new CategoryModel
                {
                    Id = entity.Id,
                    Name = entity.CategoryName,
                    Description = entity.CategoryDescription
                };
                modelsList.Add(model);
            }

            return modelsList;
        }

        public async Task<CategoryModel> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            var model = new CategoryModel();

            if (category == null)
            {
                return model;
            }

            model = new CategoryModel
            {
                Id = category.Id,
                Name = category.CategoryName,
                Description = category.CategoryDescription
            };

            return model;
        }

        public async Task Update(int id, CategoryModel model)
        {
            var entityToBeUpdated = await _categoryRepository.GetByIdAsync(id);

            if (entityToBeUpdated == null)
            {
                return;
            }

            entityToBeUpdated.CategoryName = model.Name;
            entityToBeUpdated.CategoryDescription = model.Description;

            await _categoryRepository.UpdateAsync(entityToBeUpdated);
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
