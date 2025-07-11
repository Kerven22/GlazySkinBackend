using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;
using GlazySkinBackend.Stroage.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GlazySkinBackend.Stroage.Storage.CategoryStorage;

public class GetSingleCategoryStorage:IGetSingleCategoryStorage
{
    private readonly GlazySkinDbContext _dbContext;

    public GetSingleCategoryStorage(GlazySkinDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<CategoryDto> GetSingleGategory(Guid Id, CancellationToken cancellationToken)
    {
        var categoryDto = _dbContext.Categories
            .Where(c=>Id.Equals(c.CategoryId))
            .Select((c => new CategoryDto() { Id = c.CategoryId, Name = c.Name }))
            .FirstOrDefaultAsync(cancellationToken);
        return categoryDto; 
    }
}