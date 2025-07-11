using GlazySkin.Domain.UseCases.CategoryUseCase.Models;
using GlazySkin.Domain.UseCases.Exceptions;

namespace GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;

public class GetSingleCategoryUseCase:IGetSingleCategoryUseCase
{
    private readonly IGetSingleCategoryStorage _getSingleCategoryStorage; 
    public GetSingleCategoryUseCase(IGetSingleCategoryStorage getSingleCategoryStorage)
    {
        _getSingleCategoryStorage = getSingleCategoryStorage; 
    }
    public async Task<CategoryDto> Execute(Guid Id, CancellationToken cancellationToken)
    {
        var categoryDto = await _getSingleCategoryStorage.GetSingleGategory(Id, cancellationToken);
        
        if (categoryDto is null)
            throw new CategoryNotFoundException(Id); 

        return categoryDto; 
    }
}