using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domains.Agg.ProductPicture;

namespace ShopManagment.Infrastructure.EFCore.Mappings;

public class ProductPictureMapping:IEntityTypeConfiguration<ProductPicture>
{
    public void Configure(EntityTypeBuilder<ProductPicture> builder)
    {
        builder.ToTable("ProductPictures");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.PictureAlt).HasMaxLength(255).IsRequired();
        builder.Property(x => x.PictureTitle).HasMaxLength(255).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductPictures)
            .HasForeignKey(x => x.ProductId);
    }
}