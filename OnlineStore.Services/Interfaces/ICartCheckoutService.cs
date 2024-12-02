using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface ICartCheckoutService
    {
        Task<OrderModel> CartCheckout(int cartId, int customerId);
    }
}