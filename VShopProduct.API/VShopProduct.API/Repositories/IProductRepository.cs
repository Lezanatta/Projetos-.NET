using VShopProduct.API.Controllers;
using VShopProduct.API.Models;

namespace VShopProduct.API.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product> Create(Product category);
    Task<Product> Update(Product category);
    Task<Product> Delete(int id);
}
