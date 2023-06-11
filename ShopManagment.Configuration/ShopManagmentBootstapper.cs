using BestShop.Query.Contracts.ProductCategory;
using BestShop.Query.Queries.ProductCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Application.Services;
using ShopManagment.Domains.Agg.Product;
using ShopManagment.Domains.Agg.ProductCategory;
using ShopManagment.Domains.Agg.ProductPicture;
using ShopManagment.Infrastructure.EFCore.Context;
using ShopManagment.Infrastructure.EFCore.Repositories;

namespace ShopManagment.Configuration {
    public  class ShopManagmentBootstapper {
        public static void Configure( IServiceCollection service, string connctionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();

            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();

            service.AddDbContext<ShopDbContext>(op =>
            {
                op.UseSqlServer(connctionString);
            });
        }
    }
}