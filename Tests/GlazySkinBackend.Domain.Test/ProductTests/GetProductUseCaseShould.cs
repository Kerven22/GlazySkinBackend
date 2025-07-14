using FluentAssertions;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkin.Domain.UseCases.Exceptions;
using GlazySkin.Domain.UseCases.ProductUseCases.GetProductsUseCase;
using GlazySkin.Domain.UseCases.ProductUseCases.Models;
using Moq;
using Moq.Language.Flow;

namespace GlazySkinBackend;

public class GetProductUseCaseShould
{
    private readonly GetProductUseCase sut;
    private readonly ISetup<IGetSingleCategoryStorage, Task<bool>> categoryStorageSetup;
    private readonly ISetup<IGetProductStorage, Task<ProductDto>> productStorageSetup;

    public GetProductUseCaseShould()
    {
        var categoryStorage = new Mock<IGetSingleCategoryStorage>();
        var productStorage = new Mock<IGetProductStorage>();
        productStorageSetup = productStorage.Setup(p =>
            p.GetSingleProduct(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<CancellationToken>())); 
        categoryStorageSetup = categoryStorage.Setup(s => s.CategoryExists(It.IsAny<Guid>(), It.IsAny<CancellationToken>())); 
        sut = new GetProductUseCase(categoryStorage.Object, productStorage.Object); 
    }

    [Fact]
    public async Task  ThrowNotCategoryException_WhenCategoryNotFound()
    {
        var categoryId = Guid.Parse("288b7fd5-1629-45db-a05a-0feadc8ee30e");
        var productId = Guid.Parse("405cc4c5-30d5-462d-935b-64a0dbce8491");

        categoryStorageSetup.ReturnsAsync(false); 
        await sut.Invoking(p => p.Execute(categoryId, productId, CancellationToken.None))
            .Should().ThrowAsync<CategoryNotFoundException>(); 
    }

    [Fact]
    public async Task ThrowProductNotFoundException_WhenNoMatchinProduct()
    {
        var categoryId = Guid.Parse("288b7fd5-1629-45db-a05a-0feadc8ee30e");
        var productId = Guid.Parse("405cc4c5-30d5-462d-935b-64a0dbce8491");
        categoryStorageSetup.ReturnsAsync(true);
        productStorageSetup.ReturnsAsync((ProductDto)null);
        await sut.Invoking(p => p.Execute(categoryId, productId, CancellationToken.None))
            .Should().ThrowAsync<ProductNotFoundException>();
    }
}