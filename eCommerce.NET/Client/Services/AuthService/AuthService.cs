namespace eCommerce.NET.Client.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }
    public async Task<ServiceResponse<int>> Register(UserRegister request)
    {
        var result = await _http.PostAsJsonAsync("api/auth/register", request);
        if (result == null)
        {
            return new ServiceResponse<int>
            {
                Success = false,
                Message = "Error"
            };
        }
        return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }
}