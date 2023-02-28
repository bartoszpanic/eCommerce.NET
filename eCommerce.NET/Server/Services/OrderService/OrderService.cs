using System.Security.Claims;
using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly ICartService _cartService;
    private readonly IHttpContextAccessor _contextAccessor;

    public OrderService(DataContext context,
        ICartService cartService,
        IHttpContextAccessor contextAccessor)
    {
        _context = context;
        _cartService = cartService;
        _contextAccessor = contextAccessor;
    }

    private int GetUserId() => int.Parse(_contextAccessor.HttpContext
        .User.FindFirstValue(ClaimTypes.NameIdentifier));
    
    public async Task<ServiceResponse<bool>> PlaceOrder()
    {
        var products = (await _cartService.GetDbCartProducts()).Data;
        decimal totalPrice = 0;
        
        products.ForEach(product => totalPrice += product.Price * product.Quantity);

        var orderItems = new List<OrderItem>();
        products.ForEach(product => orderItems.Add(new OrderItem()
        {
            ProductId = product.ProductId,
            ProductTypeId = product.ProductTypeId,
            Quantity = product.Quantity,
            TotalPrice = product.Price * product.Quantity
        }));

        var order = new Order()
        {
            UserId = GetUserId(),
            OrderItems = orderItems,
            OrderDate = DateTime.Now,
            TotalPrice = totalPrice
        };

        _context.Orders.Add(order);
        
        _context.CartItems.RemoveRange(_context.CartItems
            .Where(c => c.UserId == GetUserId()));
        
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool>() { Data = true, Message = "", Success = true };
    }
}