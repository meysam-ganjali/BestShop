using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contracts.Product;
using SliderMangment.Application.Contracts.Slider;

namespace BestShop.Host.Areas.Admin.Pages.Slider
{
    public class IndexModel : PageModel
    {
        private readonly ISliderApplication _sliderApplication;

        public IndexModel(ISliderApplication sliderApplication)
        {
            _sliderApplication = sliderApplication;
        }

        public List<SliderViewModel> Sliders;
        public SliderSearchModel SearchModel;
        [TempData] public string Message { get; set; }
        public void OnGet(SliderSearchModel model)
        {
            Sliders = _sliderApplication.Search(model);
        }
        public IActionResult OnGetCreate() {
            return Partial("./Create", new CreateSlider());
        }

        public JsonResult OnPostCreate(CreateSlider command) {
            var result = _sliderApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id) {
            var command = _sliderApplication.GetDetailes(id);
            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditSlider command) {
            var result = _sliderApplication.Edit(command);
            return new JsonResult(result);
        }



        public IActionResult OnGetRemove(long id) {
            var result = _sliderApplication.Remove(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id) {
            var result = _sliderApplication.Restore(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
