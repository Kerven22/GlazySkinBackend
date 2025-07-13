namespace GlazySkin.Domain.UseCases.Exceptions;

public class ProductNotFoundException:Exception
{
    public ProductNotFoundException(Guid productId):base($"Product not found with Id: {productId}")
    {

    }
}