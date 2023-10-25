using Microsoft.AspNetCore.Mvc;
using VShopProduct.API.DTOs;
using VShopProduct.API.Services;

namespace VShopProduct.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;
    public CategoriesController(ICategoryService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categoriesDto = await _service.GetCategories();
        if (categoriesDto is null)
            return NotFound();
        return Ok(categoriesDto);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProduct()
    {
        var categoriesDto = await _service.GetCategoriesProducts();
        if (categoriesDto is null)
            return NotFound();
        return Ok(categoriesDto);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> Get(int id)
    {
        var categoriesDto = await _service.GetCategoryById(id);
        if (categoriesDto is null)
            return NotFound();
        return Ok(categoriesDto);
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return BadRequest("invalid data");

        await _service.AddCategory(categoryDTO);
        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.CategoryId }, categoryDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.CategoryId)
            return BadRequest();

        if (categoryDTO is null)
            return BadRequest();

        await _service.UpdateCategory(categoryDTO);

        return Ok(categoryDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var category = await _service.GetCategoryById(id);

        if (category is null)
            return NotFound();

        await _service.RemoveCategory(category.CategoryId);

        return Ok(category);
    }

}
