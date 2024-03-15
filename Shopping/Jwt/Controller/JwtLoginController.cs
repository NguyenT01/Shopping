using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.Jwt.Service;

namespace Shopping.API.Jwt.Controller
{
    [Route("login")]
    [ApiController]
    public class JwtLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public JwtLoginController(IConfiguration configuration) { _configuration = configuration; }

        [HttpPost]
        public IActionResult UserLogin([FromBody] UserLoginDTO userDTO)
        {
            if (JwtLoginService.AuthenticateUser(userDTO))
            {
                var jwtConfig = _configuration.GetSection("JwtConfig");
                var tokenString = JwtLoginService.GenerateJWT(jwtConfig);
                return Ok(new { token = tokenString });
            }
            return Unauthorized();
        }
    }
}
