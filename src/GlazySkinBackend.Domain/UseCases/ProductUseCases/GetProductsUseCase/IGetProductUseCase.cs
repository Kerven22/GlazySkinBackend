using GlazySkin.Domain.UseCases.ProductUseCases.Models;

namespace GlazySkin.Domain.UseCases.ProductUseCases.GetProductsUseCase;

public interface IGetProductUseCase
{
    Task<ProductDto> Execute(Guid categoryId, Guid productId, CancellationToken cancellationToken); 
}