using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerce.Service.Application
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(UserDto user);
        string GenerateRefreshToken();
        (ClaimsPrincipal, JwtSecurityToken) ValidateToken(string token);
    }
}