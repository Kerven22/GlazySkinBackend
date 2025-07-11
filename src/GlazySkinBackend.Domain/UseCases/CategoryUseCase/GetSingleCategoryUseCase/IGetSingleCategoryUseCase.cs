using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;

public interface IGetSingleCategoryUseCase
{
    Task<CategoryDto> Execute(Guid Id, CancellationToken cancellationToken); 
}