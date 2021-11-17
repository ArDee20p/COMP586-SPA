using COMP586.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace COMP586.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userDto.UserName);
            
            if (user is null)
            {
                return NotFound();
            }

            bool result = await _userManager.CheckPasswordAsync(user, userDto.Password);

            if (!result)
            {
                return Ok(new { result = false });
            }

            SymmetricSecurityKey secretKey = new(Encoding.UTF8.GetBytes("CSUN586JLORDVehicleInfoS#cretK#y"));
            SigningCredentials signingCreds = new(secretKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken tokenOptions = new(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCreds
                );
            
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(string userName, string password)
        {
            ApplicationUser user = new()
            {
                UserName = userName,
                Email = $"{userName}@gmail.com",
                EmailConfirmed = true
            };
            IdentityResult result = await _userManager.CreateAsync(user, password);
            return Ok(result);
        }
    }

    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
