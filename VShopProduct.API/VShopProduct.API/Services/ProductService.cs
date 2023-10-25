using AutoMapper;
using VShopProduct.API.DTOs;
using VShopProduct.API.Models;
using VShopProduct.API.Repositories;

namespace VShopProduct.API.Services;
public class ProductService : IProductService
{
	private readonly IProductRepository _repository;
	private readonly IMapper _mapper;
	public ProductService(IProductRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var products = await _repository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }
    public async Task<ProductDTO> GetProductById(int id)
    {
        var product = await _repository.GetById(id);
        return _mapper.Map<ProductDTO>(product);
    }
    public async Task AddProduct(ProductDTO productDto)
    {
        var prod = _mapper.Map<Product>(productDto);
        await _repository.Create(prod);
        productDto.Id = prod.Id;
    }
    public async Task UpdateProduct(ProductDTO productDto)
    {
        var prod = _mapper.Map<Product>(productDto);
        await _repository.Update(prod);
    }
    public async Task RemoveProduct(int id)
    {
        var productEntity = await _repository.GetById(id);
        await _repository.Delete(productEntity.Id);
    }
}
