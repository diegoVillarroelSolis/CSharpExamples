using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplexJwtAuthentication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplexJwtAuthentication.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("login")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public bool validateToken() { return true; }

        [Route("user")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
            => Json(await _userService.LoginAsync(user.Name, user.Password));

        [AllowAnonymous]
        [HttpPost]
        public string LoginUser([FromBody] UserDTO user)
        {
            return (user.Name == "user" && user.Password == "secret") ? "true" : "false";
        }

        public class UserDTO
        {
            public String Name { get; set; }
            public String Password { get; set; }
        }
    }
}