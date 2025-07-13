using System.ComponentModel.DataAnnotations.Schema;

namespace GlazySkinBackend.Stroage.Entities.Models;

public class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public Guid CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
}