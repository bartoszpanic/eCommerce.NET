﻿using eCommerce.NET.Shared;

namespace eCommerce.NET.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        string Message { get; set; }
        List<Product> Products { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int id);
        Task SearchProducts(string searchText);
        Task<List<string>> GetProductsSearchSuggestions(string searchText);
    }
}
