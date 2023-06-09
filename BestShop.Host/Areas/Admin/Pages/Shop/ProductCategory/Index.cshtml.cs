using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contracts.ProductCategory;

namespace BestShop.Host.Areas.Admin.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }


        public List<ProductCategoryViewModel> ProductCategories;

        public ProductCategorySearchModel SearchModel;
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate() {
            return Partial("./Create", new CreateProductCategory());
        }
        public JsonResult OnPostCreate(CreateProductCategory command) {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var model = _productCategoryApplication.GetDetailes(id);
            return Partial("./Edit", model);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productCategoryApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id) {
            var result = _productCategoryApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
