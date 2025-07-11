using GlazySkinBackend.Stroage.Entities.Configurations;
using GlazySkinBackend.Stroage.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GlazySkinBackend.Stroage.DbContexts;

public class GlazySkinDbContext:DbContext
{
    public GlazySkinDbContext(DbContextOptions<GlazySkinDbContext> options):base(options){ }
    
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration()); 
        base.OnModelCreating(modelBuilder);
    }
}