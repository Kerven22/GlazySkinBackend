using FluentValidation;
using GlazySkin.Domain.UseCases.ProductUseCases.Models;

namespace GlazySkin.Domain.UseCases.ProductUseCases.CreateProductUseCase;

public class ProductCommandValidator:AbstractValidator<ProductCommand>
{
    public ProductCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithErrorCode("Product Name should not be empty")
            .MaximumLength(30).WithErrorCode("Length not be long than 30 characters");
        RuleFor(p => p.price).NotEmpty().WithErrorCode("Price for product must be.").GreaterThanOrEqualTo(0)
            .WithErrorCode("Price can not be minus value"); 
    }
}