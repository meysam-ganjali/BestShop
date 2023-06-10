using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;

namespace BestShop.Host.Areas.Admin.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication) {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }
        
        public void OnGet(ProductSearchModel searchModel) {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate() {
            var command = new CreateProduct {
                Categories = _productCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", command);
        }
        
        public JsonResult OnPostCreate(CreateProduct command) {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _productApplication.GetDetailes(id);
            command.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetNotInStok(long id)
        {
            var result = _productApplication.NotInStock(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetIsInStock(long id) {
            var result = _productApplication.IsInStock(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRemove(long id) {
            var result = _productApplication.Remove(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id) {
            var result = _productApplication.Restore(id);
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
