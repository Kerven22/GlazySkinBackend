using GlazySkin.Domain.UseCases.ProductUseCases.GetProductsUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GlazySkinBackend.Controllers;

[ApiController]
[Route("categories")]
public class ProductController:ControllerBase
{
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts(
    [FromServices] GetProductUseCase getProductUseCase,
        Guid categoryId, 
        CancellationToken cancellationToken)
    {
        return Ok(); 
    }
}