using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;

public class CreateCategoryUseCase:ICreateCategoryUseCase
{
    public Task<CategoryDto> Execute(CategoryCommand categoryCommand, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}