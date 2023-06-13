using InventoryManagment.Domains.Agg.Inventory;
using InventoryManagment.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Infrastructure.EFCore.Context;

public class InventoryDbContext:DbContext
{
    public DbSet<Inventory> Inventory { get; set; }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}