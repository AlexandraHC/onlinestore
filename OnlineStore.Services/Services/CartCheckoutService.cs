using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Services
{
    public class CartCheckoutService : ICartCheckoutService
    {
        private ICartService _cartService;
        private IProductService _productService;

        public CartCheckoutService(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public async Task<OrderModel> CartCheckout(int cartId, int customerId)
        {
            var orderModel = new OrderModel();

            if (cartId < 1 || customerId < 1)
            {
                return orderModel;
            }

            var cartModel = await _cartService.Get(cartId);

            if (cartModel == null)
            {
                return orderModel;
            }

            orderModel.OrderDate = DateTime.Now;
            orderModel.CustomerId = customerId;

            foreach (var cartItem in cartModel.CartItems)
            {
                var product = await _productService.GetById(cartItem.ProductId);

                if (product == null)
                {
                    continue;
                }

                var orderLineModel = new OrderLineModel
                {
                    ProductId = product.Id,
                    PriceWithoutVat = product.PriceWithoutVat,
                    PriceWithVat = product.PriceWithVat,
                    Quantity = cartItem.Quantity
                };

                orderModel.OrderLines.Add(orderLineModel);
            }

            orderModel.TotalAmountWithoutVat = orderModel.OrderLines.Select(line => line.PriceWithoutVat * line.Quantity).Sum();
            orderModel.TotalAmountWithVat = orderModel.OrderLines.Select(line => line.PriceWithVat * line.Quantity).Sum();

            await _cartService.Delete(cartId);

            return orderModel;
        }
    }
}
