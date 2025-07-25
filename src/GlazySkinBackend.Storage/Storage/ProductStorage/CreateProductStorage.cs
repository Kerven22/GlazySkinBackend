using GlazySkin.Domain.UseCases.ProductUseCases.CreateProducrUseCase;
using GlazySkin.Domain.UseCases.ProductUseCases.Models;
using GlazySkinBackend.Stroage.DbContexts;
using GlazySkinBackend.Stroage.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GlazySkinBackend.Stroage.Storage.ProductStorage;

public class CreateProductStorage:ICreateProductStorage
{
    private readonly GlazySkinDbContext _glazySkinDbContext;

    public CreateProductStorage(GlazySkinDbContext glazySkinDbContext)
    {
        _glazySkinDbContext = glazySkinDbContext;
    }
    public async Task<ProductDto> CreateProduct(Guid categoryId, string name, decimal price, CancellationToken cancellationToken)
    {
        var productId = Guid.NewGuid(); 
        var product = new Product()
        {
            CategoryId = categoryId,
            ProductId = productId,
            Name = name,
            Price = price
        }; 
        
        await _glazySkinDbContext.Products.AddAsync(product, cancellationToken);
        await _glazySkinDbContext.SaveChangesAsync(cancellationToken);

        var produtcDto = await _glazySkinDbContext.Products
            .Where(p => p.Category.Equals(categoryId) && p.ProductId.Equals(productId))
            .Select(p=>new ProductDto(){Categoryid = p.CategoryId, Id = p.ProductId, Name = p.Name, Price = p.Price})
            .FirstOrDefaultAsync(cancellationToken);
        return produtcDto; 
    }
}