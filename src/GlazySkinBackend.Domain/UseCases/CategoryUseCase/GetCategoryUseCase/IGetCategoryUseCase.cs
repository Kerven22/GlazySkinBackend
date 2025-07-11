using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;

public interface IGetCategoryUseCase
{
    Task<IEnumerable<CategoryDto>> Execute(CancellationToken cancellationToken); 
}