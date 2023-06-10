using Framework.IGenericRepository;
using SliderMangment.Application.Contracts.Slider;

namespace SliderManagment.Domains.Agg.Slider;

public interface ISliderRepository:IRepository<long,Slider>
{
    List<SliderViewModel> Search(SliderSearchModel model);
    EditSlider? GetDetailes(long id);
}