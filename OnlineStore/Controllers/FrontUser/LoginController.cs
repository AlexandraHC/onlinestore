using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.API.Controllers.FrontUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginUserModel model)
        {
            var userModel = await _userService.GetByEmailAndPassword(model.Email, model.Password);

            if (userModel == null) 
            {
                return BadRequest();
            }

            return Ok(userModel);
        }
    }
}
