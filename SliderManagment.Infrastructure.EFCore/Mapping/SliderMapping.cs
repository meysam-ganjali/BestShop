using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SliderManagment.Domains.Agg.Slider;

namespace SliderManagment.Infrastructure.EFCore.Mapping;

public class SliderMapping:IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.ToTable("Sliders");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Heading).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Text).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Link).HasMaxLength(1000);
        builder.Property(x => x.LinkText).HasMaxLength(255);
        builder.Property(x => x.BtnColorCode).HasMaxLength(15);
        builder.Property(x => x.PictureAlt).HasMaxLength(255);
        builder.Property(x => x.PictureTitle).HasMaxLength(255);

    }
}