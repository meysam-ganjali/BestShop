using Framework.OprationRes;

namespace InventoryManagment.Application.Contracts.Inventory;

public interface IInventoryApplication
{
    OprationResult Create(CreateInventory command);
    OprationResult Edit(EditInventory command);
    OprationResult Increase(IncreaseInventory command);
    OprationResult Reduce(ReduceInventory command);
    OprationResult Reduce(List<ReduceInventory> command);
    EditInventory? GetDetails(long id);
    List<InventoryViewModel> Search(InventorySearchModel searchModel);
    List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
}