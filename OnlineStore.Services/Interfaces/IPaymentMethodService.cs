using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface IPaymentMethodService
    {
        Task Add(PaymentMethodModel model);
        Task<IEnumerable<PaymentMethodModel>> Get();
        Task<PaymentMethodModel> GetById(int id);
        Task Update(int id, PaymentMethodModel model);
        Task Delete(int id);
    }
}
