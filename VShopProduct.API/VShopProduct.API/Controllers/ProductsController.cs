using Microsoft.AspNetCore.Mvc;
using VShopProduct.API.DTOs;
using VShopProduct.API.Services;

namespace VShopProduct.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductService _service;
    public ProductsController(IProductService service, ILogger<ProductsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var products = await _service.GetProducts();
        if (products is null)
            return NotFound("Product not found");

        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {        
        var product = await _service.GetProductById(id);
       
        if (product is null)
            return NotFound("Product not found");
        
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
    {
        if (productDto is null)
            return BadRequest("Invalid data");

        await _service.AddProduct(productDto);

        return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
            return BadRequest("Invalid data");

        await _service.UpdateProduct(productDTO);

        return Ok(productDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await _service.GetProductById(id);

        if (product is null)
            return NotFound("Product not found");

        await _service.RemoveProduct(id);

        return Ok(product);
    }
}
