using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;

public interface ICreateCategoryUseCase
{
    Task<CategoryDto> Execute(CategoryCommand categoryCommand, CancellationToken cancellationToken); 
}