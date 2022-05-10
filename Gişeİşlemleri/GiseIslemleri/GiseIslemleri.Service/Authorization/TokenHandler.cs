using GiseIslemleri.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GiseIslemleri.Service.Authorization
{
    public class TokenHandler
    {
        private IConfiguration Configuration { get; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public Token CreateAccessToken(User user)
        {
            var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            new Claim(ClaimTypes.NameIdentifier,
                Guid.NewGuid().ToString())
        };

            Token tokenInstance = new Token();

            
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            tokenInstance.Expiration = DateTime.Now.AddDays(1);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenInstance.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: claims
            );

          
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            
            tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);
            return tokenInstance;
        }
    }
}
