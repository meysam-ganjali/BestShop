using BestShop.Query.Contracts.Slider;
using BestShop.Query.Queries.SliderQuery;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SliderManagment.Application.Services;
using SliderManagment.Domains.Agg.Slider;
using SliderManagment.Infrastructure.EFCore.Context;
using SliderManagment.Infrastructure.EFCore.Repositories;
using SliderMangment.Application.Contracts.Slider;

namespace SliderManagment.Configuration;

public class SliderManagmentBootstrapper
{
    public static void Configure(IServiceCollection service, string connctionString) {

        service.AddTransient<ISliderApplication, SliderApplication>();
        service.AddTransient<ISliderRepository, SliderRepository>();

        service.AddTransient<ISliderQuery, SliderQuery>();

        service.AddDbContext<SliderDbConext>(op => {
            op.UseSqlServer(connctionString);
        });
    }
}