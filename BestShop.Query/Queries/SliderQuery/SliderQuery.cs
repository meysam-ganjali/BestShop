using BestShop.Query.Contracts.Slider;
using SliderManagment.Infrastructure.EFCore.Context;

namespace BestShop.Query.Queries.SliderQuery;

public class SliderQuery : ISliderQuery {
    private readonly SliderDbConext _sliderContext;

    public SliderQuery(SliderDbConext sliderContext) {
        _sliderContext = sliderContext;
    }
    public List<SiteSliderViewModel> GetSliders() {
        return _sliderContext.Sliders.Where(x=>x.IsRemove == false)
            .Select(x => new SiteSliderViewModel() {
            BtnColorCode = x.BtnColorCode,
            Heading = x.Heading,
            Id = x.Id,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            Link = x.Link,
            LinkText = x.LinkText,
            PictureTitle = x.PictureTitle,
            Text = x.Text,
            Title = x.Title,
        }).ToList();
    }
}