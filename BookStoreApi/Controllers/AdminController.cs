// <auto-generated />
using BussinessLayer.Interfaces;
using Common_Layer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL _adminBL;
        private readonly string _secret;
        private readonly string _issuer;


        public AdminController(IAdminBL dataRepository, IConfiguration config)
        {
            _adminBL = dataRepository;
            _secret = config.GetSection("Jwt").GetSection("Key").Value;
            _issuer = config.GetSection("Jwt").GetSection("Issuer").Value;


        }

        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody] Admin model)
        {
            try
            {



                var user = _adminBL.Authenticate(model.Email, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _issuer,
                    Audience = _issuer,
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                     new Claim("Id", Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim("ServiceType", "Admin"),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(600),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // return basic user info and authentication token
                return Ok(new
                {
                    success = true,
                    Email = user.Email,
                    Password = "*******",
                    Token = tokenString
                }) ;
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
