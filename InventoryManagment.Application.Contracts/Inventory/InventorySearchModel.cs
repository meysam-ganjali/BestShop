namespace InventoryManagment.Application.Contracts.Inventory;

public class InventorySearchModel {
    public long ProductId { get; set; }
    public bool InStock { get; set; }
}