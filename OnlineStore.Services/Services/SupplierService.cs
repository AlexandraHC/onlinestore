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
    public class SupplierService : ISupplierService
    {
        private IGenericRepository<Supplier> _supplierRepository;

        public SupplierService(IGenericRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task Add(SupplierModel model)
        {
            var supplierEntity = new Supplier
            {
                Name = model.Name
            };

            await _supplierRepository.AddAsync(supplierEntity);
        }

        public async Task Delete(int id)
        {
            await _supplierRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SupplierModel>> Get()
        {
            var allSuppliers = await _supplierRepository.GetAllAsync();

            var modelsList = new List<SupplierModel>();
            foreach (var entity in allSuppliers)
            {
                var model = new SupplierModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                };
                modelsList.Add(model);
            }

            return modelsList;
        }

        public async Task<SupplierModel> GetById(int id)
        {
            var entity = await _supplierRepository.GetByIdAsync(id);

            var model = new SupplierModel();

            if (entity == null)
            {
                return model;
            }

            model.Name = entity.Name;

            return model;
        }

        public async Task Update(int id, SupplierModel model)
        {
            var entityToBeUpdated = await _supplierRepository.GetByIdAsync(id);

            if (entityToBeUpdated == null)
            {
                return;
            }

            entityToBeUpdated.Name = model.Name;

            await _supplierRepository.UpdateAsync(entityToBeUpdated);
        }
    }
}
