using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineStore.Persistence.Entities;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Services
{
    public class ProductService : IProductService
    {
        private IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(ProductModel model)
        {
            var productEntity = new Product
            {
                IsActive = model.IsActive,
                CategoryId = model.CategoryId,
                PriceWithoutVat = model.PriceWithoutVat,
                ProductDescription = model.ProductDescription,
                PriceWithVat = model.PriceWithVat,
                ProductName = model.ProductName
            };

            await _productRepository.AddAsync(productEntity);
        }

        public async Task Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductModel>> Get(int categoryId, int pageNo, int pageSize)
        {
            var products = (await _productRepository.GetAllAsync())
                            .Where(p => p.IsActive == true && p.CategoryId == categoryId)
                            .Skip((pageNo - 1) * pageSize)
                            .Take(pageSize);

            var modelsList = MapProductsToModel(products);
            return modelsList;
        }

        public async Task<IEnumerable<ProductModel>> Get()
        {
            var allProducts = await _productRepository.GetAllAsync();

            var modelsList = MapProductsToModel(allProducts);
            return modelsList;
        }

        public async Task<ProductModel> GetById(int id)
        {
            var entity = await _productRepository.GetByIdAsync(id);

            var model = new ProductModel();

            if (entity == null)
            {
                return model;
            }

            model.ProductName = entity.ProductName;
            model.IsActive = entity.IsActive;
            model.CategoryId = entity.CategoryId;
            model.Id = entity.Id;
            model.PriceWithVat = entity.PriceWithVat;
            model.ProductDescription = entity.ProductDescription;
            model.PriceWithoutVat = entity.PriceWithoutVat;

            return model;
        }

        public async Task Update(int id, ProductModel model)
        {
            var entity = await _productRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return;
            }

            entity.PriceWithoutVat = model.PriceWithoutVat;
            entity.ProductDescription = model.ProductDescription;
            entity.PriceWithVat = model.PriceWithVat;
            entity.IsActive = model.IsActive;
            entity.CategoryId = model.CategoryId;
            entity.ProductDescription = model.ProductDescription;
            entity.ProductName = model.ProductName;

            await _productRepository.UpdateAsync(entity);
        }

        private IEnumerable<ProductModel> MapProductsToModel(IEnumerable<Product> products)
        {
            var modelsList = new List<ProductModel>();

            foreach (var entity in products)
            {
                var model = new ProductModel
                {
                    ProductName = entity.ProductName,
                    IsActive = entity.IsActive,
                    CategoryId = entity.CategoryId,
                    Id = entity.Id,
                    PriceWithoutVat = entity.PriceWithoutVat,
                    ProductDescription = entity.ProductDescription,
                    PriceWithVat = entity.PriceWithVat
                };
                modelsList.Add(model);
            }

            return modelsList;
        }
    }
}
