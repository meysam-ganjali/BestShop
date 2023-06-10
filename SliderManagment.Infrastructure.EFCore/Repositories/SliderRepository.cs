using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SliderManagment.Domains.Agg.Slider;
using SliderManagment.Infrastructure.EFCore.Context;
using SliderMangment.Application.Contracts.Slider;

namespace SliderManagment.Infrastructure.EFCore.Repositories;

public class SliderRepository : BaseRepository<long, Slider>, ISliderRepository {
    private readonly SliderDbConext _conext;

    public SliderRepository(SliderDbConext context) : base(context) {
        _conext = context;
    }

    public List<SliderViewModel> Search(SliderSearchModel model) {
        var query = _conext.Sliders.Select(x => new SliderViewModel() {
            CreationDate = x.CreatedDate,
            Heading = x.Heading,
            Id = x.Id,
            IsRemoved = x.IsRemove,
            Picture = x.Picture,
            Title = x.Title
        });
        if (!string.IsNullOrWhiteSpace(model.Title))
            query = query.Where(x => x.Title.Contains(model.Title));
        if (!string.IsNullOrWhiteSpace(model.Heading))
            query = query.Where(x => x.Heading.Contains(model.Heading));
        return query.OrderByDescending(x => x.CreationDate).ToList();
    }

    public EditSlider? GetDetailes(long id) {
        return _conext.Sliders.Select(x => new EditSlider() {
            BtnColorCode = x.BtnColorCode,
            Heading = x.Heading,
            Id = x.Id,
            Picture = x.Picture,
            Title = x.Title,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Link = x.Link,
            LinkText = x.LinkText,
            Text = x.Text,
        }).FirstOrDefault(x => x.Id == id);
    }
}