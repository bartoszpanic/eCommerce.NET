﻿using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponse>>> GetCartProductsAsync(List<CartItem> cartItems);
    }
}