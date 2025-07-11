using FluentValidation;
using GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GlazySkinBackend.Domain.DependencyInjection;

public static class GlazySkinDomainExtentions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IGetCategoryUseCase, GetCategoryUseCase>()
            .AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>()
            .AddScoped<IGetSingleCategoryUseCase, GetSingleCategoryUseCase>();
        services.AddValidatorsFromAssemblyContaining<CategoryDto>(); 
        
        return services; 
    }
}