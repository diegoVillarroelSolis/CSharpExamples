using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt_authentication.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        // POST api/Login
        [HttpPost]
        public IActionResult ValidateUser([FromBody]UserDto user)
        {
            if (user.Name == "user" && user.Password == "secret")
            {
                return Ok("The user has been succesfully autthenticated");
            }
            return BadRequest("Could not verify username and password");
        }

        public class UserDto
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public string Password { get; set; }

        }
    }
}