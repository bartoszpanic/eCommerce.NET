using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
    }
}
