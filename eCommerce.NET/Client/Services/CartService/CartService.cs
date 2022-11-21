using Blazored.LocalStorage;

namespace eCommerce.NET.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = GetCart();
            cart.ToList();
            cart.Add(cartItem);

            await _localStorage.SetItemAsync("cart", cart);
        }

        public Task<List<CartItem>> GetCartItems()
        {
            throw new NotImplementedException();
        }

        private async Task<List<CartItem>> GetCart()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            return cart;
        }
    }
}
