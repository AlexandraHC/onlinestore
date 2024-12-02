using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;

namespace OnlineStore.API.Controllers.FrontUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListingController : ControllerBase
    {
        private IProductService _productService;

        public ProductListingController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int categoryId, int pageNo, int pageSize)
        {
            if (categoryId < 1 || pageNo < 0 || pageSize < 1)
            {
                return BadRequest();
            }

            var model = await _productService.Get(categoryId, pageNo, pageSize);
            return Ok(model);
        }
    }
}
