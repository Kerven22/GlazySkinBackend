using FluentValidation;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;

public class CreateCategoryUseCase:ICreateCategoryUseCase
{
    private readonly ICreateCategoryStorage _storage;
    private readonly IValidator<CategoryCommand> _validator; 

    public CreateCategoryUseCase(ICreateCategoryStorage storage, IValidator<CategoryCommand> validator)
    {
        _storage = storage;
        _validator = validator; 
    }
    public async Task<CategoryDto> Execute(CategoryCommand categoryCommand, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(categoryCommand, cancellationToken);
        
        var category = await _storage.CreateCategory(categoryCommand.Name, cancellationToken);

        return category; 
    }
}