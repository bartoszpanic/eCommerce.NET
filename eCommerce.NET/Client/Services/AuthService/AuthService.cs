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

    public async Task<ServiceResponse<string>> Login(UserLogin request)
    {
        var result = await _http.PostAsJsonAsync("api/auth/login", request);
        if (result == null)
        {
            return new ServiceResponse<string>
            {
                Success = false,
                Message = "Error"
            };
        }
        return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }
}