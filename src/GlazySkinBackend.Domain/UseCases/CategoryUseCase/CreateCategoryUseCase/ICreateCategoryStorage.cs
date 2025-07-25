using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;

public interface ICreateCategoryStorage
{
    Task<CategoryDto> CreateCategory(string name, CancellationToken cancellationToken); 
}