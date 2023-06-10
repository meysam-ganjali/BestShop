using Framework.OprationRes;

namespace SliderMangment.Application.Contracts.Slider;

public interface ISliderApplication
{
    OprationResult Create(CreateSlider command);
    OprationResult Edit(EditSlider command);
    List<SliderViewModel> Search(SliderSearchModel model);
    EditSlider? GetDetailes(long id);
    OprationResult Remove(long id);
    OprationResult Restore(long id);
}