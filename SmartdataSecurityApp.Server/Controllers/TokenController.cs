using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartdataSecurity.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartdataSecurityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;

        public TokenController(IConfiguration config)
        {
            _configuration = config;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok("Success");
        }
        [HttpPost]
        public async Task<IActionResult> GetAuthToken([FromBody] LoginRequest _request)

        {
            if (string.IsNullOrEmpty(_request.UserName) || string.IsNullOrEmpty(_request.Password))
            {
                return BadRequest("Email or password is missing.");
            }
            //Validate login with database
            //var user = await _manager.ValidateLogin(request.UserName, request.Password);
           
            var user = new Employee() { Email = _request.UserName, Password = _request.Password, EmployeeFirstName="admin"};

            if (user != null)
            {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", user.EmployeeFirstName),
                        new Claim("Email", user.Email)
                    };

                var key =  (_configuration["Jwt:JwtTokenKey"]);
                var tokenHandler = new JwtSecurityTokenHandler();
                var byteKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token =  tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                return Ok(new
                {
                    token
                });
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
            
        }
    }
}
