using FluentAssertions;
using GlazySkin.Domain.UseCases.ProductUseCases.CreateProductUseCase;
using GlazySkin.Domain.UseCases.ProductUseCases.Models;

namespace GlazySkinBackend;

public class ProductCommandValidatorShould
{
    private readonly ProductCommandValidator sut;

    public ProductCommandValidatorShould()
    {
        sut = new ProductCommandValidator(); 
    }

    [Fact]
    public async Task ReturnTrue_WhenCommandIsValid()
    {
        var actual = await sut.ValidateAsync(new ProductCommand("hello", 23.4m));
        
        actual.IsValid.Should().BeTrue();
    }


    public static IEnumerable<object[]> GetInvalidResult()
    {
        var command = new ProductCommand("Anti-Age", 45.5m);
        yield return new object[] { command with { Name = "" } };
        yield return new object[] { command with { Name = string.Empty } };
        yield return new object[] { command with { price = -1 } };
    }

    [Theory]
    [MemberData(nameof(GetInvalidResult))]
    public void ReturnFalse_WhenCommandIsInvalid(ProductCommand productCommand)
    {
        var actual = sut.Validate(productCommand);
        actual.IsValid.Should().BeFalse();
    }
}