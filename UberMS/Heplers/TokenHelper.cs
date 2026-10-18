using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UberMS.Models;

namespace UberMS.Heplers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly IConfiguration _config;

        public TokenHelper(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.Id)),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:SecretKey"]));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var tokenOBJ = new JwtSecurityToken(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    claims: claims,
                    signingCredentials: signingCredentials,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["JWT:ExpirationInMinutes"]))
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenOBJ);
        }
    }
}
