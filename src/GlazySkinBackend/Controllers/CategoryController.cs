using GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlazySkinBackend.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController:ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetCategories([FromServices] IGetCategoryUseCase getCategoryUseCase, CancellationToken cancellationToken)
        {
            var categories = await getCategoryUseCase.Execute(cancellationToken); 
            return Ok(categories); 
        }

        [HttpGet("{Id:guid}", Name = nameof(GetSingleCategory))]
        public async Task<IActionResult> GetSingleCategory(
            [FromServices] IGetSingleCategoryUseCase getSingleCategoryUseCase,
            Guid Id, CancellationToken cancellationToken)
        {
            var category = await getSingleCategoryUseCase.Execute(Id, cancellationToken);
            return Ok(category); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            [FromServices] ICreateCategoryUseCase categoryUseCase,
            CategoryCommand categoryCommand,
            CancellationToken cancellationToken)
        {
            await categoryUseCase.Execute(categoryCommand, cancellationToken);
            return CreatedAtRoute(nameof(GetSingleCategory), new { categoryCommand.Name }); 
        }
    }
}
