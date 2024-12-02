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
    public class CartService : ICartService
    {
        private IGenericRepository<Cart> _cartRepository;

        public CartService(IGenericRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartModel> Get(int id)
        {
            var cart = await _cartRepository.GetByIdAsync(id);

            var cartModel = new CartModel();

            if (cart == null)
            {
                return cartModel;
            }

            cartModel.UserId = cart.UserId;
            cartModel.Id = cart.Id;

            foreach (var item in cart.CartItems)
            {
                var cartItemModel = new CartItemModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                cartModel.CartItems.Add(cartItemModel);
            }

            return cartModel;
        }

        public async Task AddItemToCart(AddCartItemModel cartItemModel)
        {
            var userCart = (await _cartRepository.GetAllAsync()).FirstOrDefault(c => c.UserId == cartItemModel.UserId);

            if (userCart == null)
            {
                userCart = new Cart
                {
                    UserId = cartItemModel.UserId
                };

                await _cartRepository.AddAsync(userCart);
            }         

            var cartItemEntity = new CartItem
            {
                CartId = userCart.Id,
                ProductId = cartItemModel.CartItemModel.ProductId,
                Quantity = cartItemModel.CartItemModel.Quantity
            };

            userCart.CartItems.Add(cartItemEntity);
            await _cartRepository.UpdateAsync(userCart);
        }

        public async Task DeleteItemFromCart(int cartId, int cartItemId)
        {
            var cartEntity = await _cartRepository.GetByIdAsync(cartId);

            if (cartEntity == null)
            {
                return;
            }

            var cartItemToBeDeleted = cartEntity.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);

            if (cartItemToBeDeleted == null)
            {
                return;
            }

            cartEntity.CartItems.Remove(cartItemToBeDeleted);

            await _cartRepository.UpdateAsync(cartEntity);
        }

        public async Task UpdateItemInCart(CartItemModel model)
        {
            var cartEntity = await _cartRepository.GetByIdAsync(model.CartId);

            if (cartEntity == null)
            {
                return;
            }

            var cartItemEntity = cartEntity.CartItems.FirstOrDefault(ci => ci.Id == model.CartItemId);

            if (cartItemEntity == null)
            {
                return;
            }

            cartItemEntity.ProductId = model.ProductId;
            cartItemEntity.Quantity = model.Quantity;

            await _cartRepository.UpdateAsync(cartEntity);
        }

        public async Task Delete(int cartId)
        {
            if (cartId < 1)
            {
                return;
            }

            await _cartRepository.DeleteAsync(cartId);
        }
    }
}
