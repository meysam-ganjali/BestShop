using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.Services;
using ShopManagment.Domains.Agg.ProductCategory;
using ShopManagment.Infrastructure.EFCore.Context;
using ShopManagment.Infrastructure.EFCore.Repositories;

namespace ShopManagment.Configuration {
    public  class ShopManagmentBootstapper {
        public static void Configure( IServiceCollection service, string connctionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddDbContext<ShopDbContext>(op =>
            {
                op.UseSqlServer(connctionString);
            });
        }
    }
}