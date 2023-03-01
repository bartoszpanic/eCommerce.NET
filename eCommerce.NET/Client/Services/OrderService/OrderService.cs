using eCommerce.NET.Client.Services.AuthService;
using Microsoft.AspNetCore.Components;

namespace eCommerce.NET.Client.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly NavigationManager _navigationManager;
    private readonly HttpClient _httpClient;
    private readonly IAuthService _authService;

    public OrderService(NavigationManager navigationManager, HttpClient httpClient, IAuthService authService)
    {
        _navigationManager = navigationManager;
        _httpClient = httpClient;
        _authService = authService;
    }
    public async Task PlaceOrder()
    {
        if (await _authService.IsUserAuthenticated())
        {
            await _httpClient.PostAsync("api/order", null);
        }
        else
        {
            _navigationManager.NavigateTo("login");
        }
    }

    public async Task<List<OrderOverviewResponse>> GetOrders()
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
        if (result == null || result.Data == null)
        {
            return new List<OrderOverviewResponse>();
        }
        return result.Data;
    }

    public async Task<OrderDetailsResponse> GetOrderDetails(int orderId)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/order/{orderId}");
        if (result == null || result.Data == null)
        {
            return new OrderDetailsResponse();
        }
        return result.Data;
    }
}