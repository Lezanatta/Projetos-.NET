using VShopProduct.API.DTOs;
using VShopProduct.API.Models;

namespace VShopProduct.API.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
    Task<CategoryDTO> GetCategoryById(int id);
    Task AddCategory(CategoryDTO category);
    Task UpdateCategory(CategoryDTO category);
    Task RemoveCategory(int id);
}
