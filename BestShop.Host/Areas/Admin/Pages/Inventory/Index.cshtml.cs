using InventoryManagment.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;

namespace BestShop.Host.Areas.Admin.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public List<InventoryViewModel> Inventories;
        public InventorySearchModel SearchModel;
        public SelectList Products;
        [TempData] public string Message { get; set; }
        public void OnGet(InventorySearchModel model)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Inventories = _inventoryApplication.Search(model);
        }
        public IActionResult OnGetCreate() {
            var command = new CreateInventory() {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateInventory command) {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id) {
            var command = _inventoryApplication.GetDetails(id);
            command.Products = _productApplication.GetProducts();
            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditInventory command) {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id) {
            var command = new IncreaseInventory() {
                InventoryId = id
            };
            return Partial("Increase", command);
        }

      
        public JsonResult OnPostIncrease(IncreaseInventory command) {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetReduce(long id) {
            var command = new ReduceInventory() {
                InventoryId = id
            };
            return Partial("Reduce", command);
        }
        public JsonResult OnPostReduce(ReduceInventory command) {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetLog(long id) {
            var log = _inventoryApplication.GetOperationLog(id);
            return Partial("OperationLog", log);
        }
    }
}
