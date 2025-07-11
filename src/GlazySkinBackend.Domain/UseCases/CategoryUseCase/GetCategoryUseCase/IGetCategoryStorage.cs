using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;

public interface IGetCategoryStorage
{
    Task<IEnumerable<CategoryDto>> GetAllCategories(CancellationToken cancellationToken); 
}