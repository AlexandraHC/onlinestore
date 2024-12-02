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
    public class StockService : IStockService
    {
        private IGenericRepository<Stock> _stockRepository;

        public StockService(IGenericRepository<Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task Add(StockModel model)
        {
            var stockEntity = new Stock
            {
                Quantity = model.Quantity,
                ProductId = model.ProductId
            };

            await _stockRepository.AddAsync(stockEntity);
        }

        public async Task Delete(int id)
        {
            await _stockRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StockModel>> Get()
        {
            var allStock = await _stockRepository.GetAllAsync();

            var modelsList = new List<StockModel>();
            foreach (var entity in allStock)
            {
                var model = new StockModel
                {
                    Id = entity.Id,
                    ProductId = entity.ProductId,
                    Quantity = entity.Quantity,
                };
                modelsList.Add(model);
            }

            return modelsList;
        }

        public async Task<StockModel> GetById(int id)
        {
            var entity = await _stockRepository.GetByIdAsync(id);

            var model = new StockModel();

            if (entity == null)
            {
                return model;
            }

            model.Id = entity.Id;
            model.Quantity = entity.Quantity;
            model.ProductId = entity.ProductId;

            return model;
        }

        public async Task Update(int id, StockModel model)
        {
            var entityToBeUpdated = await _stockRepository.GetByIdAsync(id);

            if (entityToBeUpdated == null)
            {
                return;
            }

            entityToBeUpdated.ProductId = model.ProductId;
            entityToBeUpdated.Quantity = model.Quantity;

            await _stockRepository.UpdateAsync(entityToBeUpdated);
        }
    }
}
