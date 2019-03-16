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

namespace DAD_Parking___Back.Controllers
{       
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private const string KEY = "APPLICATION_TEST_KEY";
        private UserManager<DADParkingUser> userManager;

        public AuthController(UserManager<DADParkingUser> userManager)
        {
            this.userManager = userManager;            
        }
        
        [HttpPost]
        [Route("login")]
        public async System.Threading.Tasks.Task<IActionResult> LoginAsync([FromBody] LoginModel login)
        {
            var user = await userManager.FindByNameAsync(login.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))            
            {
                var claims = new [] 
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));

                //Check issuer and audience
                var token = new JwtSecurityToken(
                    issuer: "http://oec.com",
                    audience: "http://oec.com",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok( new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    }
                );
            }

            return Unauthorized();
        } 
    }
}