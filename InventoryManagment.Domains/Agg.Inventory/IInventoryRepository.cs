using Framework.IGenericRepository;
using InventoryManagment.Application.Contracts.Inventory;

namespace InventoryManagment.Domains.Agg.Inventory;

public interface IInventoryRepository:IRepository<long,Inventory>
{
    EditInventory? GetDetails(long id);
    Inventory GetBy(long productId);
    List<InventoryViewModel> Search(InventorySearchModel searchModel);
    List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
}