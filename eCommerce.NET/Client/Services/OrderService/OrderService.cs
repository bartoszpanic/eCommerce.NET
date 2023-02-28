using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace eCommerce.NET.Client.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly NavigationManager _navigationManager;
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;

    public OrderService(NavigationManager navigationManager, HttpClient httpClient, AuthenticationStateProvider authStateProvider)
    {
        _navigationManager = navigationManager;
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
    }
    public async Task PlaceOrder()
    {
        if (await IsUserAuthenticated())
        {
            await _httpClient.PostAsync("api/order", null);
        }
        else
        {
            _navigationManager.NavigateTo("login");
        }
    }
    
    public async Task<bool> IsUserAuthenticated()
    {
        return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }
}