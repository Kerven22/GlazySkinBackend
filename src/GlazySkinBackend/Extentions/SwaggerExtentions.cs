using Microsoft.OpenApi.Models;

namespace GlazySkinBackend.Extentions
{
    public static class SwaggerExtentions
    {
        public static void CustomConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo {Title = "GlazySkinBackend - v1", Version = "v1"});
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "GlazySkinBackend.xml");
            }); 
        }
    }
}
