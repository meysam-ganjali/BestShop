using DiscountManagment.Application.Contracts.ColleagueDiscount;
using DiscountManagment.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;

namespace BestShop.Host.Areas.Admin.Pages.Discount.Colleague
{
    public class IndexModel : PageModel
    {
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication, IProductApplication productApplication)
        {
            _colleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
        }

        public List<ColleagueDiscountViewModel> ColleagueDiscount;
        public ColleagueDiscountSearchModel SearchModel;
        public SelectList Products;
        [TempData] public string Message { get; set; }
        public void OnGet(ColleagueDiscountSearchModel model)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ColleagueDiscount = _colleagueDiscountApplication.Search(model);
        }
        public IActionResult OnGetCreate() {
            var command = new DefineColleagueDiscount() {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount command) {
            var result = _colleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id) {
            var command = _colleagueDiscountApplication.GetDetails(id);
            command.Products = _productApplication.GetProducts();
            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command) {
            var result = _colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }



        public IActionResult OnGetRemove(long id) {
            var result = _colleagueDiscountApplication.Remove(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id) {
            var result = _colleagueDiscountApplication.Restore(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
