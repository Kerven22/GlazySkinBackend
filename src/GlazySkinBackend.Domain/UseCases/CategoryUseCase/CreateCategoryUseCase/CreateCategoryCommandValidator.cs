using FluentValidation;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;

public class CreateCategoryCommandValidator:AbstractValidator<CategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithErrorCode("Name is not null!"); 
    }
}