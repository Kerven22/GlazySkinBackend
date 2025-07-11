using FluentAssertions;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;
using GlazySkin.Domain.UseCases.Exceptions;
using Moq;
using Moq.Language.Flow;

namespace GlazySkinBackend;

public class GetSingleCategoryUseCaseShould
{
    private readonly GetSingleCategoryUseCase sut;
    private readonly ISetup<IGetSingleCategoryStorage, Task<CategoryDto>> storageSetup;


    public GetSingleCategoryUseCaseShould()
    {

        var storage = new Mock<IGetSingleCategoryStorage>();
        storageSetup = storage.Setup(c => c.GetSingleGategory(It.IsAny<Guid>(), It.IsAny<CancellationToken>())); 
        sut = new GetSingleCategoryUseCase(storage.Object); 
    }

    [Fact]
    public void ThrowNotFoundCategoryException_WhenNotMatchingCategory()
    {
        var category = new CategoryDto()
        {
            Id = Guid.Parse("cf83f0e9-b3b5-4414-99c1-87abad8d5a03"),
            Name = "Anti-Sun"
        };
        
        storageSetup.ReturnsAsync(category);
        
        sut.Invoking(c => c.Execute(Guid.Parse("b02b3b93-c35a-4e23-a890-e25ed54e187f"), CancellationToken.None))
            .Should().ThrowAsync<CategoryNotFoundException>(); 
    }
}