using Microsoft.EntityFrameworkCore;
using SliderManagment.Domains.Agg.Slider;
using SliderManagment.Infrastructure.EFCore.Mapping;

namespace SliderManagment.Infrastructure.EFCore.Context;

public class SliderDbConext : DbContext {
    public SliderDbConext(DbContextOptions<SliderDbConext> options) : base(options) {

    }

    public DbSet<Slider> Sliders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SliderMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}