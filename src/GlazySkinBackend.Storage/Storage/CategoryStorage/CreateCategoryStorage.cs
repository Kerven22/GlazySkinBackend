using GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;
using GlazySkinBackend.Stroage.DbContexts;
using GlazySkinBackend.Stroage.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GlazySkinBackend.Stroage.Storage.CategoryStorage;

public class CreateCategoryStorage:ICreateCategoryStorage
{
    private readonly GlazySkinDbContext _dbContext;
    private readonly IGuidFactory _guidFactory; 

    public CreateCategoryStorage(GlazySkinDbContext dbContext, IGuidFactory guidFactory)
    {
        _dbContext = dbContext;
        _guidFactory = guidFactory; 
    }
    public async Task<CategoryDto> CreateCategory(string name, CancellationToken cancellationToken)
    {
        var id = _guidFactory.Create();
        var category = new Category()
        {
            CategoryId = id, 
            Name = name

        };
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync(cancellationToken);

         return await _dbContext.Categories
            .Select(c=>new CategoryDto(){Id=c.CategoryId, Name = c.Name})
            .FirstAsync(cancellationToken);
    }
}