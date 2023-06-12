using DiscountManagment.Domains.Agg.ColleagueDiscount;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagment.Infrastructure.EFCore.Mapping;
public class ColleagueDiscountMapping : IEntityTypeConfiguration<ColleagueDiscount> {
    public void Configure(EntityTypeBuilder<ColleagueDiscount> builder) {
        builder.ToTable("ColleagueDiscounts");
        builder.HasKey(x => x.Id);
    }
}