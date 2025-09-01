using Microsoft.AspNetCore.Mvc;
using NKatmanliMimariOrnegi.Business.Interfaces;
using NKatmanliMimariOrnegi.DTOs.Product;

namespace NKatmanliMimariOrnegi.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GET()
    {
        var result = await _productService.GetAllProductsAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GET(int id)
    {
        var result = await _productService.GetProductByIdAsync(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> POST(ProductAddDto dto)
    {
        await _productService.AddProductAsync(dto);
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> PUT(ProductUpdateDto dto)
    {

        await _productService.UpdateProduct(dto);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DELETE(int id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok();
    }
}
