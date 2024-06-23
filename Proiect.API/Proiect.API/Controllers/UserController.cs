using Proiect.Core.Services;
using Proiect.Database.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Proiect.API.Controllers
{
    public class UserController:BaseController
    {
        private UserService userService { get; set; }


        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterRequest payload)
        {
            userService.Register(payload);
            return Ok("Registration successful");
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest payload)
        {
            var jwtToken = userService.Login(payload);

            return Ok(new { token = jwtToken });
        }
    }
}
