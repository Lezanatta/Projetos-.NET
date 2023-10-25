using System.Text;
using System.Text.Json;
using Vshop.WEB.Models;
using Vshop.WEB.Services.Contracts;

namespace Vshop.WEB.Services;
public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clienteFactory;
    private const string _apiEndpoint = "/api/products/";
    private readonly JsonSerializerOptions _options;
    private ProductViewModel _productVM;
    private IEnumerable<ProductViewModel> _products;
    public ProductService(IHttpClientFactory clienteFactory)
    {
        _clienteFactory = clienteFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
    {
        var cliente = _clienteFactory.CreateClient("ProductApi");
        using var response = await cliente.GetAsync(_apiEndpoint);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            _products = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse ,_options);
        }
        else
        {
            return null;
        }
        return _products;
    }
    public async Task<ProductViewModel> FindProductById(int id)
    {
        var cliente = _clienteFactory.CreateClient("ProductApi");
        using var response = await cliente.GetAsync(_apiEndpoint + id);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            _productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
        }
        else
        {
            return null;
        }
        return _productVM;

    }
    public async Task<ProductViewModel> CreateProduct(ProductViewModel product)
    {
        var cliente = _clienteFactory.CreateClient("ProductApi");

        var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

        using var response = await cliente.PostAsync(_apiEndpoint, content);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            _productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
        }
        else
        {
            return null;
        }
        return _productVM;
    }
    public async Task<ProductViewModel> UpdateProduct(ProductViewModel product)
    {
        var cliente = _clienteFactory.CreateClient("ProductApi");

        var productUpdated = new ProductViewModel();

        using var response = await cliente.PutAsJsonAsync(_apiEndpoint, product);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            productUpdated = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
        }
        else
        {
            return null;
        }
        return productUpdated;
    }
    public async Task<bool> DeleteProductById(int id)
    {
        var cliente = _clienteFactory.CreateClient("ProductApi");
        using var response = await cliente.DeleteAsync(_apiEndpoint + id);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;       
    }
}
