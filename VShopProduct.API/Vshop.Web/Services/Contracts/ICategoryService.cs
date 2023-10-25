using Vshop.WEB.Models;

namespace Vshop.WEB.Services.Contracts;
public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllCategories();
}
