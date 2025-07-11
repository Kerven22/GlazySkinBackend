using GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace GlazySkinBackend.Domain.DependencyInjection;

public static class GlazySkinDomainExtentions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IGetCategoryUseCase, GetCategoryUseCase>();
        return services; 
    }
}