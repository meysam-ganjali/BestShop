using DiscountManagment.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductPicture;
using SliderMangment.Application.Contracts.Slider;

namespace BestShop.Host.Areas.Admin.Pages.Discount.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication, IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }
        public List<CustomerDiscountViewModel> CustomerDiscounts;
        public CustomerDiscountSearchModel SearchModel;
        public SelectList Products;
        [TempData] public string Message { get; set; }
        public void OnGet(CustomerDiscountSearchModel model)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            CustomerDiscounts = _customerDiscountApplication.Search(model);
        }
        public IActionResult OnGetCreate() {
            var command = new DefineCustomerDiscount() {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command) {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id) {
            var command = _customerDiscountApplication.GetDetails(id);
            command.Products = _productApplication.GetProducts();
            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditCustoemrDiscount command) {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }



        public IActionResult OnGetRemove(long id) {
            var result = _customerDiscountApplication.Remove(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id) {
            var result = _customerDiscountApplication.Restore(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
