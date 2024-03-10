using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthorization.Shared.Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly byte[] _secret;
        private readonly double _expirationTime;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtHandler(IConfiguration configuration)
        {
            _secret = Encoding.UTF8.GetBytes(configuration.GetRequiredSection("Jwt:Secret").Value);
            _expirationTime = double.Parse(configuration.GetRequiredSection("Jwt:Expiration").Value);
            _issuer = configuration.GetRequiredSection("Jwt:Issuer").Value;
            _audience = configuration.GetRequiredSection("Jwt:Audience").Value;
        }

        public string GenerateToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var expiration = DateTime.Now.AddMinutes(_expirationTime);

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, username),
                new(JwtRegisteredClaimNames.Exp, expiration.ToString()),
                new("role", role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiration,
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
