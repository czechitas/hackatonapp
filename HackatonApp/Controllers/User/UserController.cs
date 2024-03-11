using Microsoft.AspNetCore.Mvc;

namespace HackatonApp.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public Task<IActionResult> Login()
        {
            Console.WriteLine("Login");
            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
