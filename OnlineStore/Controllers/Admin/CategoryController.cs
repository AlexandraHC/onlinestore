using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryModel model)
        {
            await _categoryService.Add(model);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _categoryService.GetAll();

            return Ok(models);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var model = await _categoryService.GetById(id);

            if (model.Id == 0)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryModel model)
        {
            await _categoryService.Update(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {         
            await _categoryService.Delete(id);

            return Ok();
        }

    }
}
