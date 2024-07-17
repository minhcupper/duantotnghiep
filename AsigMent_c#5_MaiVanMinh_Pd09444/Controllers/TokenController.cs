using AsigMent_c_5_MaiVanMinh_Pd09444.Model;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AsigMent_c_5_MaiVanMinh_Pd09444.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbcontext _Context;
        // GET: api/<TokenController>
        public TokenController(IConfiguration configuration, AppDbcontext context)
        {
            _configuration = configuration;
            _Context = context;

        }
        // POST api/<TokenController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user != null && user.username != null && user.password != null)
            {
                var users = await getuser(user.username, user.password);
                if (users != null)
                {
                    var claims = new[]

                   {
                        new Claim(JwtRegisteredClaimNames.Sub,users.username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
                        new Claim("UserName",users.username ?? string.Empty),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signingCredentials);
                    var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                    Console.WriteLine($"Generated token: {tokenstring}");
                    return Ok(tokenstring);
                }
                else
                {
                    return BadRequest("invalid");
                }
            }
            else
            {
                return BadRequest();
            }

        }

     

        private async Task<User> getuser(string username, string pass)
        {
            return _Context.users.FirstOrDefault(e => e.username == username && e.password == pass);
        }
    }
}
