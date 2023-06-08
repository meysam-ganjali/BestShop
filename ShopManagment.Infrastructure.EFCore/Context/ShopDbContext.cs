using Microsoft.EntityFrameworkCore;
using ShopManagment.Domains.Agg.ProductCategory;
using ShopManagment.Infrastructure.EFCore.Mappings;

namespace ShopManagment.Infrastructure.EFCore.Context;

public class ShopDbContext:DbContext
{
    public DbSet<ProductCategory> ProductCategories { get; set; }

    public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ProductCategoryMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}