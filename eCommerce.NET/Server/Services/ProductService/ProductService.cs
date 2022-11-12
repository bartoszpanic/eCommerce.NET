using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            //implement strategy pattern
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.ToListAsync()
            };

            return response;
        }
    }
}
