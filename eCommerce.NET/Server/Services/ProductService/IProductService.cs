using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetAllProductsAsync();
    }
}
