using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductSupplierController : ControllerBase
    {
        private IProductSupplierService _productSupplierService;

        public ProductSupplierController(IProductSupplierService productSupplierService)
        {
            _productSupplierService = productSupplierService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductSupplierModel model)
        {
            await _productSupplierService.Add(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _productSupplierService.Get();
            return Ok(models);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }

            var model = await _productSupplierService.GetById(id);

            if (model.Id == 0)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductSupplierModel model)
        {
            await _productSupplierService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productSupplierService.Delete(id);
            return Ok();
        }
    }
}
