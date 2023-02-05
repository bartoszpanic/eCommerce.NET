﻿using System.Security.Claims;
using eCommerce.NET.Server.Services.CartService;
using eCommerce.NET.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.NET.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("products")]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = await _cartService.GetCartProductsAsync(cartItems);

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItems(List<CartItem> cartItems)
        {
            var result = await _cartService.StoreCartItems(cartItems);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>>  GetCartItemsCount()
        {
            var result = await _cartService.GetCartItemsCount();

            return Ok(result);
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>>  GetDbCartProducts()
        {
            var result = await _cartService.GetDbCartProducts();

            return Ok(result);
        }
        
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddCartItems(CartItem cartItem)
        {
            var result = await _cartService.AddToCart(cartItem);

            return Ok(result);
        }

    }
}
