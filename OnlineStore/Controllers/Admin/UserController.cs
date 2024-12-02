using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;

namespace OnlineStore.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models =  await _userService.GetAll();

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }

            var userModel = await _userService.GetById(id);

            if (userModel.Id == 0)
            {
                return NotFound();
            }

            return Ok(userModel);
        }   
    }
}
