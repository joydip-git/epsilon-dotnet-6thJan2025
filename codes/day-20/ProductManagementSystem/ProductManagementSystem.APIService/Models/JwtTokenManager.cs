using Microsoft.IdentityModel.Tokens;
using ProductManagementSystem.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementSystem.APIService.Models
{
    public class JwtTokenManager(IConfiguration configuration) : ITokenManager
    {
        public string GenerateJSONWebToken(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"] ?? "productmanagementapiserverissuerkeyforjwttoken"));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(type:JwtRegisteredClaimNames.Sub, value:user.UserId),
                    new Claim(type:JwtRegisteredClaimNames.Email, user.UserId),
                    new Claim(type:JwtRegisteredClaimNames.Jti,value:new Guid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials,
                    claims: claims);

                //WriteToken method: Serializes a JwtSecurityToken into a JWT in Compact Serialization Format. [A JWE or JWS in 'Compact Serialization Format'.]
                var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
                return serializedToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
