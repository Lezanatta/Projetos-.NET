using Microsoft.EntityFrameworkCore;
using VShopProduct.API.Context;
using VShopProduct.API.Models;

namespace VShopProduct.API.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Category>> GetAll() => await _context.Categories.ToListAsync();

    public async Task<IEnumerable<Category>> GetCategoriesProducts() => await _context.Categories.Include(prod => prod.Products).ToListAsync();

    public async Task<Category> GetById(int id) => await _context.Categories.Where(cat => cat.CategoryId == id).FirstOrDefaultAsync();

    public async Task<Category> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Delete(int id)
    {
        var category = await GetById(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}
