using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domains.Agg.ProductCategory;

namespace ShopManagment.Infrastructure.EFCore.Mappings;

public class ProductCategoryMapping:IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Des).HasMaxLength(500);
        builder.Property(x => x.Picture).HasMaxLength(1000);
        builder.Property(x => x.PictureAlt).HasMaxLength(255);
        builder.Property(x => x.PictureTitle).HasMaxLength(255);
        builder.Property(x => x.MetaDes).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.KeyWord).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(1000).IsRequired();

        builder.HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}