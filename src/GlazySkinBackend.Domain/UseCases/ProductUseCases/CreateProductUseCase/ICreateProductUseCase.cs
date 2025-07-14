using GlazySkin.Domain.UseCases.ProductUseCases.Models;

namespace GlazySkin.Domain.UseCases.ProductUseCases.CreateProducrUseCase;

public interface ICreateProductUseCase
{
    Task<ProductDto> Execute(Guid categoryId, ProductCommand command, CancellationToken cancellationToken); 
}