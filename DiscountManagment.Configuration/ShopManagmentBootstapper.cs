using DiscountManagment.Application.Contracts.CustomerDiscount;
using DiscountManagment.Application.Services;
using DiscountManagment.Domains.Agg.CustomersDiscount;
using DiscountManagment.Infrastructure.EFCore.Context;
using DiscountManagment.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ShopManagment.Configuration {
    public  class DiscountManagmentBootstapper {
        public static void Configure( IServiceCollection service, string connctionString)
        {
            service.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            service.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            
            service.AddDbContext<DiscountDbContext>(op =>
            {
                op.UseSqlServer(connctionString);
            });
        }
    }
}