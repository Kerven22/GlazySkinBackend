using GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GlazySkinBackend.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController:ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromServices] IGetCategoryUseCase getCategoryUseCase, CancellationToken cancellationToken)
        {
            var categories = await getCategoryUseCase.Execute(cancellationToken); 
            return Ok(categories); 
        }
    }
}
