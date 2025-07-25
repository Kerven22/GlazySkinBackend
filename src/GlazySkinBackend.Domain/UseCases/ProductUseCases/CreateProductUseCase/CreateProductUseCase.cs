using FluentValidation;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkin.Domain.UseCases.Exceptions;
using GlazySkin.Domain.UseCases.ProductUseCases.Models;

namespace GlazySkin.Domain.UseCases.ProductUseCases.CreateProducrUseCase;

public class CreateProductUseCase:ICreateProductUseCase
{
    private readonly ICreateProductStorage _createProductStorage;
    private readonly IValidator<ProductCommand> _validator;
    private readonly IGetSingleCategoryStorage _getCategoryExist;

    public CreateProductUseCase(
        ICreateProductStorage createProductStorage,
        IValidator<ProductCommand> validator, 
        IGetSingleCategoryStorage getCategoryExist)
    {
        _createProductStorage = createProductStorage;
        _validator = validator;
        _getCategoryExist = getCategoryExist;
    }
    
    public async Task<ProductDto> Execute(Guid categoryId, ProductCommand command, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(command);

        var categoryExist = await _getCategoryExist.CategoryExists(categoryId, cancellationToken);
        if (!categoryExist)
            throw new CategoryNotFoundException(categoryId);

        var productDto = await _createProductStorage.CreateProduct(categoryId, command.Name, command.price, cancellationToken);

        return productDto;
    }
}