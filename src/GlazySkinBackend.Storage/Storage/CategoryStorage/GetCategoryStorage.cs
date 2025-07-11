using GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;
using GlazySkinBackend.Stroage.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GlazySkinBackend.Stroage.Storage.CategoryStorage;

public class GetCategoryStorage:IGetCategoryStorage
{
    private readonly GlazySkinDbContext _dbContext;

    public GetCategoryStorage(GlazySkinDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
    public async Task<IEnumerable<CategoryDto>> GetAllCategories(CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories
            .Select(c => new CategoryDto() { Id = c.CategoryId, Name = c.Name })
            .ToArrayAsync(cancellationToken);
        return categories; 
    }
}