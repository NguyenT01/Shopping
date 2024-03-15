using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shopping.API.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Shopping.API.Jwt.Service
{
    public static class JwtLoginService
    {
        public static bool AuthenticateUser(UserLoginDTO userDTO)
        {
            return !(userDTO.username.IsNullOrEmpty() || userDTO.password.IsNullOrEmpty());
        }

        public static string GenerateJWT(IConfigurationSection config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Key").Value!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                config.GetSection("Issuer").Value!,
                config.GetSection("Audience").Value!,
                null,
                expires: DateTime.Now.AddMinutes(double.Parse(config.GetSection("ExpireInMinutes").Value!)),
                signingCredentials: credentials
                );

            // Results look like: "Bearer __key__"
            return JwtBearerDefaults.AuthenticationScheme + " " + new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
