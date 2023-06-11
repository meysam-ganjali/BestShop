using BestShop.Query.Contracts.ProductCategory;
using BestShop.Query.Contracts.Slider;
using BestShop.Query.Queries.ProductCategory;
using BestShop.Query.Queries.SliderQuery;
using Microsoft.Extensions.DependencyInjection;

namespace BestShop.Query.Boostrapper;

public class BestShop_Bootstrapper
{
    public static void Configure(IServiceCollection service) {

        service.AddTransient<ISliderQuery, SliderQuery>();
        service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
    }
}