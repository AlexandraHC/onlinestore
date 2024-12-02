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
    public class ProductSupplierService : IProductSupplierService
    {
        private IGenericRepository<ProductSupplier> _productSupplierRepository;

        public ProductSupplierService(IGenericRepository<ProductSupplier> productSupplierRepository)
        {
            _productSupplierRepository = productSupplierRepository;
        }

        public async Task Add(ProductSupplierModel model)
        {
            var productSupplierEntity = new ProductSupplier
            {
                Id = model.Id,
                ProductId = model.ProductId,
                SupplierId = model.SupplierId
            };

            await _productSupplierRepository.AddAsync(productSupplierEntity);
        }

        public async Task Delete(int id)
        {
            await _productSupplierRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductSupplierModel>> Get()
        {
            var allProductSuppliers = await _productSupplierRepository.GetAllAsync();

            var modelsList = new List<ProductSupplierModel>();
            foreach (var entity in allProductSuppliers)
            {
                var model = new ProductSupplierModel
                {
                    Id = entity.Id,
                    ProductId = entity.ProductId,
                    SupplierId = entity.SupplierId
                };

                modelsList.Add(model);
            }
            return modelsList;
        }

        public async Task<ProductSupplierModel> GetById(int id)
        {
            var entity = await _productSupplierRepository.GetByIdAsync(id);

            var model = new ProductSupplierModel();

            if (entity == null)
            {
                return model;
            }

            model.Id = entity.Id;
            model.ProductId = entity.ProductId;
            model.SupplierId = entity.SupplierId;

            return model;
        }

        public async Task Update(int id, ProductSupplierModel model)
        {
            var entity = await _productSupplierRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return;
            }

            entity.SupplierId = model.SupplierId;
            entity.ProductId = model.ProductId;

            await _productSupplierRepository.UpdateAsync(entity);
        }
    }
}
