using Microsoft.Extensions.Options;

namespace ECommerce.Service.Application
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IJwtTokenService _jwtTokenService;
        private readonly JwtTokenSettings _jwtTokenSettings;

        public AuthenticationService(IJwtTokenService jwtTokenService, IOptions<JwtTokenSettings> jwtTokenSettings)
        {
            _jwtTokenService = jwtTokenService;
            _jwtTokenSettings = jwtTokenSettings.Value;
        }

        public AuthResponseDto Login(string username, string password)
        {
            // Here you would typically validate the user credentials against a database
            // and generate an access token and refresh token.
            // For simplicity, we are returning a dummy response.
            // Varsayın ki kullanıcı adı ve şifre kontrolü başarılı oldu.
            var user = new UserDto
            {
                Id = Guid.NewGuid(),
                UserName = username,
                Email = $"ab@xxx.com"
            };

            var accessToken = _jwtTokenService.GenerateAccessToken(user);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();
            var expiresAt = DateTime.UtcNow.AddDays(_jwtTokenSettings.AccessTokenExpirationDays);

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = expiresAt,
                User = user
            };







        }
    }

}
