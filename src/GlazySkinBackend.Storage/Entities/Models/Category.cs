using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlazySkinBackend.Stroage.Entities.Models;

public class Category
{
    
    public Guid CategoryId { get; set; }
    
    [Required(ErrorMessage = "Category Name is must be not null!")]
    public string? Name { get; set; }
    
    public ICollection<Product> Products { get; set; }
}