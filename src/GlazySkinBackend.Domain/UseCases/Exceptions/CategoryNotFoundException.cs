namespace GlazySkin.Domain.UseCases.Exceptions;

public class CategoryNotFoundException:Exception
{
    public CategoryNotFoundException(Guid Id) : base($"Category with Id:{Id} was not found!") { }
}