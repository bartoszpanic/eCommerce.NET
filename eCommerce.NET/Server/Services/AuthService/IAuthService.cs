using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(User user, string password);
}