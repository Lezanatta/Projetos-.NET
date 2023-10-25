using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vshop.WEB.Models;
using Vshop.WEB.Services.Contracts;

namespace Vshop.WEB.Controllers;
public class ProductsController : Controller
{
    private readonly IProductService _service;
    private readonly ICategoryService _categoryService;
    public ProductsController(IProductService service, ICategoryService categoryService)
    {
        _service = service;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
    {
        var result = await _service.GetAllProducts();

        if (result is null)
            return View("Erro");

        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(), "CategoryId", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductViewModel productVm)
    {
        if (ModelState.IsValid)
        {
            var result = await _service.CreateProduct(productVm);

            if (result != null)
                return RedirectToAction(nameof(Index));
        }
        else
        {
            ViewBag.CategoryId = new SelectList(await
                _categoryService.GetAllCategories(), "CategoryId", "Name");
        }

        return View(productVm);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        ViewBag.CategoryId = new SelectList(await 
            _categoryService.GetAllCategories(), "CategoryId", "Name");

        var result = await _service.FindProductById(id);

        if (result is null)
            return View("Error");

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(ProductViewModel productVm)
    {
        if(ModelState.IsValid)
        {
            var result = await _service.UpdateProduct(productVm);

            if (result is not null)
                RedirectToAction(nameof(Index));
        }

        return View(productVm);
    }

    [HttpGet]
    public async Task<ActionResult<ProductViewModel>> DeleteProduct(int id)
    {
        var result = await _service.FindProductById(id);

        if (result is null)
            return View("Error");

        return View(result);
    }

    [HttpPost(), ActionName("DeleteProduct")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _service.DeleteProductById(id);

        if (!result)
            return View("Error");

        return RedirectToAction("Index");
    }
}
