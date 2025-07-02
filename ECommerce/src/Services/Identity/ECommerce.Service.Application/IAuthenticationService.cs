namespace ECommerce.Service.Application
{
    public interface IAuthenticationService
    {
        AuthResponseDto Login(string username, string password);
    }
}