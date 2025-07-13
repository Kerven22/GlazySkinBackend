using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkin.Domain.UseCases.Exceptions;
using GlazySkin.Domain.UseCases.ProductUseCases.Models;

namespace GlazySkin.Domain.UseCases.ProductUseCases.GetProductsUseCase;

public class GetProductUseCase:IGetProductUseCase
{
    private readonly IGetSingleCategoryStorage _getCategoryStorage;
    private readonly IGetProductStorage _getProductStorage; 

    public GetProductUseCase(
        IGetSingleCategoryStorage getCategoryStorage, 
        IGetProductStorage getProductStorage)
    {
        _getCategoryStorage = getCategoryStorage;
        _getProductStorage = getProductStorage;
    }
    
    public async Task<ProductDto> Execute(Guid categoryId, Guid productId, CancellationToken cancellationToken)
    {
        var categoryExists = await _getCategoryStorage.CategoryExists(categoryId, cancellationToken);
        if (!categoryExists)
            throw new CategoryNotFoundException(categoryId);
        
        var productDto = await _getProductStorage.GetSingleProduct(categoryId, productId, cancellationToken);
        if (productDto is null)
            throw new ProductNotFoundException(productId);
        
        return productDto;
    }
}