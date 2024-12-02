using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;

namespace OnlineStore.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.Get();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }
            var model = await _orderService.GetById(id);

            if (model.Id == 0)
            {
                return NotFound();
            }

            return Ok(model);
        }

    }
}
