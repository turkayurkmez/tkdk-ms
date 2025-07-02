using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Application
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtTokenSettings _jwtTokenSettings;
        public JwtTokenService(IOptions<JwtTokenSettings> jwtTokenSettings)
        {
            _jwtTokenSettings = jwtTokenSettings.Value;
        }
        public string GenerateAccessToken(UserDto user)
        {
            // Here you would typically use a library like System.IdentityModel.Tokens.Jwt to create a JWT token
            // For simplicity, we are returning a dummy token string.

            //sub,email ve jti claimleri oluştur:
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtTokenSettings.Issuer,
                audience: _jwtTokenSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtTokenSettings.AccessTokenExpirationMinutes),
                signingCredentials: creds
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            // Here you would typically generate a secure random string for the refresh token
            // For simplicity, we are returning a dummy token string.
            var randomBytes = new byte[64]; // 256 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }


        }

        public (ClaimsPrincipal, JwtSecurityToken) ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSettings.Secret)),
                ValidateIssuer = true,
                ValidIssuer = _jwtTokenSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtTokenSettings.Audience,
                ValidateLifetime = true,
                // No clock skew
            };
            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return (principal, validatedToken as JwtSecurityToken);
            }
            catch (Exception ex)
            {
                // Handle token validation failure (e.g., log the error, throw an exception, etc.)
                return (null, null);
            }
        }




    }
}
