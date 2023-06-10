using Microsoft.EntityFrameworkCore;
using ShopManagment.Domains.Agg.Product;
using ShopManagment.Domains.Agg.ProductCategory;
using ShopManagment.Domains.Agg.ProductPicture;
using ShopManagment.Infrastructure.EFCore.Mappings;

namespace ShopManagment.Infrastructure.EFCore.Context;

public class ShopDbContext:DbContext
{
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductPicture> ProductPictures { get; set; }

    public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductPictureMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}