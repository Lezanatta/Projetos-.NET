using Microsoft.EntityFrameworkCore;
using VShopProduct.API.Context;
using VShopProduct.API.Controllers;
using VShopProduct.API.Models;

namespace VShopProduct.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Product>> GetAll() 
        => await _context.Products.Include(cat => cat.Category).ToListAsync();

    public async Task<Product> GetById(int id) 
        => await _context.Products.Include(cat => cat.Category).Where(prd => prd.Id == id).FirstOrDefaultAsync();

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var product = await GetById(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
