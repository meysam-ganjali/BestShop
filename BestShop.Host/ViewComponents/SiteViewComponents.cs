using BestShop.Query.Contracts.ProductCategory;
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

public class CategoryAreaViewComponent : ViewComponent {
   private readonly IProductCategoryQuery _productCategoryQuery;

   public CategoryAreaViewComponent(IProductCategoryQuery productCategoryQuery)
   {
       _productCategoryQuery = productCategoryQuery;
   }
   public async Task<IViewComponentResult> InvokeAsync()
   {
       var productCategories = _productCategoryQuery.GetAllCategory();
        return View("CategoryArea",productCategories);
    }
}