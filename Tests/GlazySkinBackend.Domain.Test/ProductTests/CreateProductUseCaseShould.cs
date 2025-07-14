using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkin.Domain.UseCases.Exceptions;
using GlazySkin.Domain.UseCases.ProductUseCases.CreateProducrUseCase;
using GlazySkin.Domain.UseCases.ProductUseCases.Models;
using Moq;
using Moq.Language.Flow;

namespace GlazySkinBackend;

public class CreateProductUseCaseShould
{
    private readonly CreateProductUseCase sut;
    private readonly ISetup<ICreateProductStorage, Task<ProductDto>> stroageSetup;
    private readonly ISetup<IValidator<ProductCommand>, ValidationResult> validatorSetup;
    private readonly ISetup<IGetSingleCategoryStorage, Task<bool>> categoryExist;

    public CreateProductUseCaseShould()
    {
        var storage = new Mock<ICreateProductStorage>();
        var validator = new Mock<IValidator<ProductCommand>>();
        var getCategoryExists = new Mock<IGetSingleCategoryStorage>();

        stroageSetup = storage.Setup(s =>
            s.CreateProduct(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<CancellationToken>()));
        validatorSetup = validator.Setup(s => s.Validate(It.IsAny<ProductCommand>()));
        categoryExist = getCategoryExists.Setup(s => s.CategoryExists(It.IsAny<Guid>(), It.IsAny<CancellationToken>())); 
        sut = new CreateProductUseCase(storage.Object, validator.Object, getCategoryExists.Object); 
    }

    [Fact]
    public void ThrowCategoryNotFoundException_WhenNotFoundMatchingCategory()
    {
        validatorSetup.Returns(new ValidationResult());
        categoryExist.ReturnsAsync(false);

        var categoryId = Guid.Parse("e2696844-3c74-4a0b-8468-19d910e9a6ed");
        var actual = sut.Invoking(cp => cp.Execute(categoryId, new ProductCommand("Anti-Age", 23.4m), CancellationToken.None));
        actual.Should().ThrowAsync<CategoryNotFoundException>(); 
    }
}