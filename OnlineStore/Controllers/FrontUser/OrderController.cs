using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;

namespace OnlineStore.API.Controllers.FrontUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private ICartCheckoutService _cartCheckoutService;

        public OrderController(IOrderService orderService, ICartCheckoutService cartCheckoutService)
        {
            _orderService = orderService;
            _cartCheckoutService = cartCheckoutService;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(int cartId, int customerId)
        {
            if (cartId < 1)
            {
                return BadRequest();
            }

            if(customerId < 1) 
            {
                return BadRequest();
            }

            var orderModel = await _cartCheckoutService.CartCheckout(cartId, customerId);

            if (orderModel == null)
            {
                return BadRequest();
            }

            await _orderService.AddOrder(orderModel);
            return Ok(orderModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var orderModel = await _orderService.GetById(id);

            if (orderModel.Id == 0)
            {
                return NotFound();
            }

            return Ok(orderModel);
        }
    }
}
