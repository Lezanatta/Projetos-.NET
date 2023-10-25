using System.Text.Json;
using Vshop.WEB.Models;
using Vshop.WEB.Services.Contracts;

namespace Vshop.WEB.Services;
public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _cliente;
    private readonly JsonSerializerOptions _options;
    private const string _apiEndpoint = "/api/categories/";
    public CategoryService(IHttpClientFactory cliente)
    {
        _cliente = cliente;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive= true };
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
    {
        var cliente = _cliente.CreateClient("ProductApi");
        IEnumerable<CategoryViewModel> categories;

        using var response = await cliente.GetAsync(_apiEndpoint);       

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
        }
        else
        {
            return null;
        }
        return categories;
    }
}
