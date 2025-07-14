using GlazySkin.Domain.UseCases.ProductUseCases.Models;

namespace GlazySkin.Domain.UseCases.ProductUseCases.CreateProducrUseCase;

public interface ICreateProductStorage
{
    Task<ProductDto> CreateProduct(Guid categoryId, string name, decimal price, CancellationToken cancellationToken); 
}