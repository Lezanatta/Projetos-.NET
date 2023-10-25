using AutoMapper;
using VShopProduct.API.DTOs;
using VShopProduct.API.Models;
using VShopProduct.API.Repositories;

namespace VShopProduct.API.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository category, IMapper mapper)
    {
        _repository = category;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoryEntity = await _repository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
    }
    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoryEntity = await _repository.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
    }
    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoryEntity = await _repository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }
    public async Task AddCategory(CategoryDTO category)
    {
        var categoryEntity = _mapper.Map<Category>(category);
        await _repository.Create(categoryEntity);
        category.CategoryId = categoryEntity.CategoryId;
    }
    public async Task UpdateCategory(CategoryDTO category)
    {
        var categoryEntity = _mapper.Map<Category>(category);
        await _repository.Update(categoryEntity);
    }
    public async Task RemoveCategory(int id)
    {
        var categoryEntity = GetCategoryById(id).Result;
        await _repository.Delete(categoryEntity.CategoryId);
    }
}
