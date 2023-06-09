using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;

namespace BestShop.Host.Areas.Admin.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }


        public List<ProductViewModel> Products;

        public ProductSearchModel SearchModel;
        public void OnGet(ProductSearchModel searchModel)
        {
            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate() {
            return Partial("./Create", new CreateProduct());
        }
        public JsonResult OnPostCreate(CreateProduct command) {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var model = _productApplication.GetDetailes(id);
            return Partial("./Edit", model);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id) {
            var result = _productApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
