using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplexJwtAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplexJwtAuthentication.Controllers
{
    [Route("login")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("hello")]
        public string hello() { return "hello"; }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
            => Json(await _userService.LoginAsync(user.Name, user.Password));
                
        public class UserDTO
        {
            public String Name { get; set; }
            public String Password { get; set; }
        }
    }
}