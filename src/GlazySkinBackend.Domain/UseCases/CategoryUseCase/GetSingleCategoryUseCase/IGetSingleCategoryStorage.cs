using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;

public interface IGetSingleCategoryStorage
{
    Task<CategoryDto> GetSingleGategory(Guid Id, CancellationToken cancellationToken); 
}