using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface ICustomerService
    {
        Task AddCustomerToUser(CustomerModel model);
    }
}
