using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DAD_Parking___Back.Data;
using DAD_Parking___Back.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace DAD_Parking___Back.Controllers
{       
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private const string KEY = "APPLICATION_TEST_KEY";
        private UserManager<DADParkingUser> userManager;

        public AuthController(UserManager<DADParkingUser> userManager)
        {
            this.userManager = userManager;            
        }

        [Authorize]
        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUser() 
        {
            var user = await userManager.FindByNameAsync(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(new 
            {
                id = user.Id,
                username = user.UserName,
                email = user.Email
            }
            );
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);

            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))            
            {
                var claims = new [] 
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
                
                var token = new JwtSecurityToken(                    
                    expires: DateTime.UtcNow.AddDays(5),
                    claims: claims,
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok( new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        user = new {
                            id = user.Id,
                            email = user.Email,
                            username = user.UserName
                        }
                    }
                );
            }

            return Unauthorized();
        } 
    }
}