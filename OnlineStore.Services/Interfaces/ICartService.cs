using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface ICartService
    {
        Task AddItemToCart(AddCartItemModel cartItemModel);

        Task DeleteItemFromCart(int cartId, int cartItemId);

        Task UpdateItemInCart(CartItemModel model);

        Task<CartModel> Get(int id);

        Task Delete(int cartId);
    }
}
