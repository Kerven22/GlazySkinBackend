using GlazySkinBackend.Domain.DependencyInjection;
using GlazySkinBackend.Extentions;
using GlazySkinBackend.Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.CustomConfigureSwagger();

builder.Services.AddDomainServices();
builder.Services.AddStorageServices(builder.Configuration.GetConnectionString("Default")); 


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers(); 

app.Run();