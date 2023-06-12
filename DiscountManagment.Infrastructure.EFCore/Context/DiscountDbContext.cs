using DiscountManagment.Domains.Agg.ColleagueDiscount;
using DiscountManagment.Domains.Agg.CustomersDiscount;
using DiscountManagment.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagment.Infrastructure.EFCore.Context;

public class DiscountDbContext:DbContext
{
    public DiscountDbContext(DbContextOptions<DiscountDbContext> options):base(options)
    {
        
    }

    public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
    public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDiscountMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColleagueDiscountMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}