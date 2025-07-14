using GlazySkin.Domain.UseCases.ProductUseCases.Models;

namespace GlazySkin.Domain.UseCases.ProductUseCases.GetProductsUseCase;

public interface IGetProductStorage
{
    Task<ProductDto?> GetSingleProduct(Guid categoryId, Guid productId, CancellationToken cancellationToken);
}