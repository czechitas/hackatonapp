using HackatonApp.Selectors.User;
using HackatonApp.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApp.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IAuthService authService) : ControllerBase
    {
        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginSelector login)
        {
            var user = await authService.AuthenticateUser(login);
            if (user != null)
                return Ok(new { token = user });

            return Unauthorized();
        }
        
        /// <summary>
        /// Register a user
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterSelector register)
        {
            var registerValid = await authService.RegisterUser(register);
            if (registerValid)
                return Ok();
            
            return BadRequest();
        }
    }
}
