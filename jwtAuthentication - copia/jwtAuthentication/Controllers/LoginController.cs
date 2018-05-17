using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwtAuthentication.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        // POST api/Login
        [HttpPost]
        public IActionResult ValidateUser([FromBody] UserDto user)
        {
            if (user.Name == "user" && user.Password == "secret")
            {
                return Ok("The user has been succesfully autthenticated");
            }
            return BadRequest("Could not verify username and password");
        }

        //[HttpPost]
        //public IActionResult RequestToken([FromBody] UserDto user)
        //{
        //    if (user.Name == "user" && user.Password == "secret")
        //    {
        //        var claims = new[]
        //        {
        //            new Claim(ClaimTypes.Name, request.Username),
        //            new Claim("CompletedBasicTraining", ""),
        //            new Claim(CustomClaimTypes.EmploymentCommenced,
        //                        new DateTime(2017,12,1).ToString(),
        //                        ClaimValueTypes.DateTime)
        //        };

        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var token = new JwtSecurityToken(
        //            issuer: "yourdomain.com",
        //            audience: "yourdomain.com",
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(30),
        //            signingCredentials: creds);

        //        return Ok(new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(token)
        //        });
        //    }

        //    return BadRequest("Could not verify username and password");
        //}

        public class UserDto
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public string Password { get; set; }

        }
    }
}