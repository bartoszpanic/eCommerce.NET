using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.OrderService;

public interface IOrderService
{
    Task<ServiceResponse<bool>> PlaceOrder();
}