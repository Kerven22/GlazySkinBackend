using GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;
using GlazySkinBackend.Stroage.DbContexts;
using GlazySkinBackend.Stroage.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GlazySkinBackend.Stroage.Storage.CategoryStorage;

public class CreateCategoryStorage:ICreateCategoryStorage
{
    private readonly GlazySkinDbContext _dbContext;

    public CreateCategoryStorage(GlazySkinDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
    public async Task<CategoryDto> CreateCategory(string Name, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        var category = new Category()
        {
            CategoryId = id, Name = Name

        };
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var categoryDto = await _dbContext.Categories
            .Select(c=>new CategoryDto(){Id=c.CategoryId, Name = c.Name})
            .FirstAsync(cancellationToken);
        return categoryDto; 
    }
}