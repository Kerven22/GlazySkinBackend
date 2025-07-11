using GlazySkin.Domain.UseCases.CategoryUseCase.Models;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;

public class GetCategoryUseCase:IGetCategoryUseCase
{
    private readonly IGetCategoryStorage _categoryStorage; 
    public GetCategoryUseCase(IGetCategoryStorage categoryStorage)
    {
        _categoryStorage = categoryStorage; 
    }
    public async Task<IEnumerable<CategoryDto>> Execute(CancellationToken cancellationToken)
    {
        var categories = await _categoryStorage.GetAllCategories(cancellationToken);
        return categories; 
    }
}