using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;

using SmartdataSecurity.Model;
using SmartdataSecurityService.Interfaces;
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
        private readonly IUserRepository _userRepository;
        private readonly ILogger<TokenController> _logger;

        public TokenController(IConfiguration config, IUserRepository userRepository, ILogger<TokenController> logger)
        {
            _configuration = config;
            _userRepository = userRepository;
            _logger = logger;
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
            //var hashedPassword = HashPassword(_request.Password);
            _logger.LogInformation("Fetching all users...");
            try
            {


                //Validate login with database
                var user = await _userRepository.ValidateLoginAsync(_request.UserName);
                if (user == null)
                {

                    return BadRequest("Invalid credentials");

                }
                var isPasswordValid = VerifyPassword(_request.Password, user.Password);
                if (!isPasswordValid)
                {

                    return Unauthorized("Invalid username or password");
                }
                //var user = new User() { UserId = _request.UserName, Password = _request.Password};

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", ""),
                        new Claim("Email", user.UserId)
                    };

                    var key = (_configuration["Jwt:JwtTokenKey"]);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var byteKey = Encoding.ASCII.GetBytes(key);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                            SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                   
                    return Ok(new
                    {
                        token,
                        user = new // Return user details along with the token
                        {
                            id = user.Id, //  
                            email = user.UserId, 
                            employeeId = user.EmployeeId,  

                        }
                    });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            catch (Exception ex)
            { 

                _logger.LogError(ex, "Error Validating User");
                return StatusCode(500, "Internal Server Error");
            }
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
