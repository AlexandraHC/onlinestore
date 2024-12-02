using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;
using OnlineStore.Services.Services;

namespace OnlineStore.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StockModel model)
        {
            await _stockService.Add(model);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _stockService.Get();

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var model = await _stockService.GetById(id);

            if (model.Id == 0)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StockModel model)
        {
            await _stockService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _stockService.Delete(id);
            return Ok();
        }

    }
}
