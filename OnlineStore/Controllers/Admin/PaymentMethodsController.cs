using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private IPaymentMethodService _paymentMethodService;

        public PaymentMethodsController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PaymentMethodModel model)
        {
            await _paymentMethodService.Add(model);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _paymentMethodService.Get();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var model = await _paymentMethodService.GetById(id);

            if (model.Id == 0)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PaymentMethodModel model)
        {
            await _paymentMethodService.Update(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentMethodService.Delete(id);

            return Ok();
        }
    }
}
