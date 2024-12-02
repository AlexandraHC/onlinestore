using OnlineStore.Persistence.Entities;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private IGenericRepository<PaymentMethod> _paymentMethodRepository;

        public PaymentMethodService(IGenericRepository<PaymentMethod> paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task Add(PaymentMethodModel model)
        {
            var paymentMethodEntity = new PaymentMethod
            {
                Name = model.Name,
                Description = model.Description
            };

            await _paymentMethodRepository.AddAsync(paymentMethodEntity);
        }

        public async Task<IEnumerable<PaymentMethodModel>> Get()
        {
            var allPaymentMethods = await _paymentMethodRepository.GetAllAsync();

            var modelsList = new List<PaymentMethodModel>();
            foreach (var entity in allPaymentMethods)
            {
                var model = new PaymentMethodModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                };
                modelsList.Add(model);
            }

            return modelsList;
        }

        public async Task<PaymentMethodModel> GetById(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);

            var model = new PaymentMethodModel();

            if (paymentMethod == null)
            {
                return model;
            }

            model = new PaymentMethodModel
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Name,
                Description = paymentMethod.Description
            };

            return model;
        }

        public async Task Update(int id, PaymentMethodModel model)
        {
            var entityToBeUpdated = await _paymentMethodRepository.GetByIdAsync(id);

            if (entityToBeUpdated == null)
            {
                return;
            }

            entityToBeUpdated.Name = model.Name;
            entityToBeUpdated.Description = model.Description;

            await _paymentMethodRepository.UpdateAsync(entityToBeUpdated);
        }

        public async Task Delete(int id)
        {
            await _paymentMethodRepository.DeleteAsync(id);
        }
    }
}
