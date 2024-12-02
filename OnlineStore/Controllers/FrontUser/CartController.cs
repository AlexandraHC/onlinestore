using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.API.Controllers.FrontUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCart([FromBody]AddCartItemModel addCartItemModel)
        {
            if (addCartItemModel == null || addCartItemModel.CartItemModel == null || addCartItemModel.UserId < 1)
            {
                return BadRequest();
            }

            await _cartService.AddItemToCart(addCartItemModel);
            return Ok();       
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int cartId, [FromQuery]int cartItemId)
        {
            if(cartId < 1 || cartItemId < 1)
            {
                return BadRequest();
            }

            await _cartService.DeleteItemFromCart(cartId, cartItemId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CartItemModel model)
        {
            await _cartService.UpdateItemInCart(model);
            return Ok();
        }


    }
}
