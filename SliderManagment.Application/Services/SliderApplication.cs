using Framework.OprationRes;
using SliderManagment.Domains.Agg.Slider;
using SliderMangment.Application.Contracts.Slider;

namespace SliderManagment.Application.Services;

public class SliderApplication : ISliderApplication {
    private readonly ISliderRepository _sliderRepository;

    public SliderApplication(ISliderRepository sliderRepository) {
        _sliderRepository = sliderRepository;
    }
    public OprationResult Create(CreateSlider command) {
        OprationResult op = new OprationResult();
        if (_sliderRepository.IsExist(x => x.Link == command.Link))
            return op.Failed("شما قبلا اسلایدری با این لینک ثبت نموده اید");
        var slider = new Slider(command.Heading, command.Title, command.Text, command.Picture, command.Link,
            command.LinkText, command.PictureAlt, command.PictureTitle, command.BtnColorCode);
        _sliderRepository.Add(slider);
        _sliderRepository.SaveChanges();
        return op.Successed("اسلایدر جدید با موفقیت ثبت شد");
    }

    public OprationResult Edit(EditSlider command) {
        OprationResult op = new OprationResult();
        var slider = _sliderRepository.Get(command.Id);
        if (slider == null)
            return op.Failed("اسلایدر یافت نشد");
        if (_sliderRepository.IsExist(x => x.Link == command.Link && x.Id != command.Id))
            return op.Failed("شما قبلا اسلایدری با این لینک ثبت نموده اید");
        slider.Edit(command.Heading, command.Title, command.Text, command.Picture, command.Link,
            command.LinkText, command.PictureAlt, command.PictureTitle, command.BtnColorCode);
        _sliderRepository.SaveChanges();
        return op.Successed("عملیات بروزرسانی با موفقیت پایان یافت");
    }

    public List<SliderViewModel> Search(SliderSearchModel model) {
        return _sliderRepository.Search(model);
    }

    public EditSlider? GetDetailes(long id)
    {
        return _sliderRepository.GetDetailes(id);
    }

    public OprationResult Remove(long id) {
       OprationResult op=new OprationResult();
       var slider = _sliderRepository.Get(id);
       if (slider == null)
           return op.Failed("اسلایدر یافت نشد");
       slider.Remove();
       _sliderRepository.SaveChanges();
       return op.Successed();
    }

    public OprationResult Restore(long id) {
        OprationResult op = new OprationResult();
        var slider = _sliderRepository.Get(id);
        if (slider == null)
            return op.Failed("اسلایدر یافت نشد");
        slider.Restore();
        _sliderRepository.SaveChanges();
        return op.Successed();
    }
}