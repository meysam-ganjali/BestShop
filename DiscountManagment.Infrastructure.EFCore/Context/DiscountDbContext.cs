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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDiscountMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}