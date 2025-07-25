namespace GlazySkin.Domain.UseCases.ProductUseCases.Models;

public class ProductDto
{
    public Guid Id { get; set; }
    
    public Guid Categoryid { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}