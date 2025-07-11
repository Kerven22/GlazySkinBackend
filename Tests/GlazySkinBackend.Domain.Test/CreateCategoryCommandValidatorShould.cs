using FluentAssertions;
using GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkinBackend;

public class CreateCategoryCommandValidatorShould
{
    private readonly CreateCategoryCommandValidator sut;

    public CreateCategoryCommandValidatorShould()
    {
        sut = new CreateCategoryCommandValidator(); 
    }

    public static IEnumerable<object[]> GetInvalidCommand()
    {
        var command = new CategoryCommand( "Anti-Age");

        yield return new object[] { command with { Name = "" } };
        yield return new object[] { command with { Name = "   " } };
        yield return new object[] { command with { Name = string.Empty } }; 
    }

    [Theory]
    [MemberData(nameof(GetInvalidCommand))]
    public void ReturnFauiler_WhenCommandIsInvalid(CategoryCommand categoryCommand)
    {
        var actual = sut.Validate(categoryCommand);
        actual.IsValid.Should().BeFalse(); 
    }

    [Fact]
    public void ReturnSucces_WhenCommandIsValid()
    {
        var actual = sut.Validate(new CategoryCommand("Anit-Age"));
        actual.IsValid.Should().BeTrue(); 

    }
}