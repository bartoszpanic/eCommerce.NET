using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public CartService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        
        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProductsAsync(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponse>>
            {
                Data = new List<CartProductResponse>()
            };

            foreach (var item in cartItems)
            {
                var product = await _context.Products
                    .Where(p => p.Id == item.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null)
                {
                    continue;
                }

                var productVariant = await _context.ProductVariants
                    .Where(v => v.ProductId == item.ProductId
                    && v.ProductTypeId == item.ProductTypeId)
                    .Include(v => v.ProductType)
                    .FirstOrDefaultAsync();

                if (productVariant == null)
                {
                    continue;
                }

                var cartproduct = new CartProductResponse
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartproduct);
            }
            return result;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            _context.CartItems.AddRange(cartItems);
            await _context.SaveChangesAsync();

            return await GetDbCartProducts();
        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            var count = (await _context.CartItems.Where(c => c.UserId == _authService.GetUserId()).ToListAsync()).Count;
            return new ServiceResponse<int>()
            {
                Data = count
            };
        }
        
        public async Task<ServiceResponse<List<CartProductResponse>>> GetDbCartProducts()
        {
            return await GetCartProductsAsync(
                await _context.CartItems.Where(c => c.UserId == _authService.GetUserId()).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();

            var sameItem = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == cartItem.ProductId &&
                                                                             c.ProductTypeId ==
                                                                             cartItem.ProductTypeId &&
                                                                             c.UserId == cartItem.UserId);
            if (sameItem == null)
            {
                _context.CartItems.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var dbItem = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == cartItem.ProductId &&
                                                                             c.ProductTypeId ==
                                                                             cartItem.ProductTypeId &&
                                                                             c.UserId == _authService.GetUserId());
            if (dbItem == null)
            {
                return new ServiceResponse<bool>() { Data = false, Message = "Cart item not exist", Success = false };
            }

            dbItem.Quantity = cartItem.Quantity;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true, Success = true };
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
        {
            var dbItem = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == productId &&
                                                                           c.ProductTypeId ==
                                                                           productTypeId &&
                                                                           c.UserId == _authService.GetUserId());
            if (dbItem == null)
            {
                return new ServiceResponse<bool>() { Data = false, Message = "Cart item not exist", Success = false };
            }

            _context.CartItems.Remove(dbItem);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Succesfuly removed",
                Success = true
            };
        }
    }
}
