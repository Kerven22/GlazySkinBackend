using GlazySkinBackend.Stroage.Entities.Configurations;
using GlazySkinBackend.Stroage.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GlazySkinBackend.Stroage.DbContexts;

public class GlazySkinDbContext:DbContext
{
    public GlazySkinDbContext(DbContextOptions<GlazySkinDbContext> options):base(options){ }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration((new ProductConfiguration())); 
        base.OnModelCreating(modelBuilder);
    }
}