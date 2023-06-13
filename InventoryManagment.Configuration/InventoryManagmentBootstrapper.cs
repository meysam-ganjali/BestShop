

using InventoryManagment.Application.Contracts.Inventory;
using InventoryManagment.Application.Services;
using InventoryManagment.Domains.Agg.Inventory;
using InventoryManagment.Infrastructure.EFCore.Context;
using InventoryManagment.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SliderManagment.Configuration;

public class InventoryManagmentBootstrapper
{
    public static void Configure(IServiceCollection service, string connctionString) {

        service.AddTransient<IInventoryApplication, InventoryApplication>();
        service.AddTransient<IInventoryRepository, InventoryRepository>();
        

        service.AddDbContext<InventoryDbContext>(op => {
            op.UseSqlServer(connctionString);
        });
    }
}