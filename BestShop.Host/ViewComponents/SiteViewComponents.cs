using BestShop.Query.Contracts.Slider;
using Microsoft.AspNetCore.Mvc;

namespace BestShop.Host.ViewComponents;

public class SliderViewComponent : ViewComponent
{
    private readonly ISliderQuery _slider;

    public SliderViewComponent(ISliderQuery slider)
    {
        _slider = slider;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {

        var sliders = _slider.GetSliders();
        return View("Slider",sliders);
    }
}