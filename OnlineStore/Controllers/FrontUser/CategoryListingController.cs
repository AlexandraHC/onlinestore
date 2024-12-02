using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;

namespace OnlineStore.API.Controllers.FrontUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryListingController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryListingController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _categoryService.GetAll();
            return Ok(model);
        }

    }
}
