using GlazySkin.Domain.UseCases.CategoryUseCase.CreateCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetCategoryUseCase;
using GlazySkin.Domain.UseCases.CategoryUseCase.GetSingleCategoryUseCase;
using GlazySkinBackend.Stroage.DbContexts;
using GlazySkinBackend.Stroage.Storage.CategoryStorage;
using Microsoft.Extensions.DependencyInjection;

namespace GlazySkinBackend.Storage.DependencyInjection;

public static class GlazySkinStorageExtentions
{
    public static IServiceCollection AddStorageServices(this IServiceCollection service, string connnectionString)
    {
        service.AddSqlServer<GlazySkinDbContext>(connnectionString, b=>b.MigrationsAssembly(nameof(GlazySkinBackend)));

        service.AddScoped<IGetCategoryStorage, GetCategoryStorage>()
            .AddScoped<ICreateCategoryStorage, CreateCategoryStorage>()
            .AddScoped<IGetSingleCategoryStorage, GetSingleCategoryStorage>();
        return service; 
    }
}