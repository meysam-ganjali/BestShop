using Framework.Validation;
using ShopManagment.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagment.Application.Contracts.Inventory;
public class CreateInventory {
    [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
    public long ProductId { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
    public double UnitPrice { get; set; }

    public List<ProductViewModel> Products { get; set; }
}