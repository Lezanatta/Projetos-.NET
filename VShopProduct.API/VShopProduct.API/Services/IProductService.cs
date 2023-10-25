using VShopProduct.API.Controllers;
using VShopProduct.API.DTOs;

namespace VShopProduct.API.Services;
public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO>GetProductById(int id);
    Task AddProduct(ProductDTO product);
    Task UpdateProduct(ProductDTO product);
    Task RemoveProduct(int id);
}
