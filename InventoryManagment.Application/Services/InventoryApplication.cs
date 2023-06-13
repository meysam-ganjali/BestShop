using System.Security.Cryptography.X509Certificates;
using Framework.OprationRes;
using InventoryManagment.Application.Contracts.Inventory;
using InventoryManagment.Domains.Agg.Inventory;

namespace InventoryManagment.Application.Services;

public class InventoryApplication : IInventoryApplication {
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryApplication(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    public OprationResult Create(CreateInventory command) {
        OprationResult op = new OprationResult();
        if (_inventoryRepository.IsExist(x => x.ProductId == command.ProductId))
            return op.Failed("رکورد تکراری است");
        Inventory inventory = new Inventory(command.ProductId, command.UnitPrice);
        _inventoryRepository.Add(inventory);
        _inventoryRepository.SaveChanges();
        return op.Successed();
    }

    public OprationResult Edit(EditInventory command) {
        OprationResult op = new OprationResult();
        var inventory = _inventoryRepository.Get(command.Id);
        if (inventory == null)
            return op.Failed("رکورد یافت نشد");
        if (_inventoryRepository.IsExist(x => x.ProductId == command.ProductId && x.Id != command.Id))
            return op.Failed("رکورد تکراری است");
        inventory.Edit(command.ProductId, command.UnitPrice);
        _inventoryRepository.SaveChanges();
        return op.Successed();
    }

    public OprationResult Increase(IncreaseInventory command) {
        var operation = new OprationResult();
        var inventory = _inventoryRepository.Get(command.InventoryId);
        if (inventory == null)
            return operation.Failed("رکورد یافت نشد");

        const long operatorId = 1;
        inventory.Increase(command.Count, operatorId, command.Description);
        _inventoryRepository.SaveChanges();
        return operation.Successed();
    }

    public OprationResult Reduce(ReduceInventory command) {
        var operation = new OprationResult();
        var inventory = _inventoryRepository.Get(command.InventoryId);
        if (inventory == null)
            return operation.Failed("رکورد یافت نشد");

        var operatorId = 1;
        inventory.Reduce(command.Count, operatorId, command.Description, 0);
        _inventoryRepository.SaveChanges();
        return operation.Successed();
    }

    public OprationResult Reduce(List<ReduceInventory> command) {
        var operation = new OprationResult();
        foreach (var item in command) {
            var inventory = _inventoryRepository.GetBy(item.ProductId);
            inventory.Reduce(item.Count, 1, item.Description, item.OrderId);
        }

        _inventoryRepository.SaveChanges();
        return operation.Successed();
    }

    public EditInventory? GetDetails(long id)
    {
        return _inventoryRepository.GetDetails(id);
    }

    public List<InventoryViewModel> Search(InventorySearchModel searchModel) {
        return _inventoryRepository.Search(searchModel);
    }

    public List<InventoryOperationViewModel> GetOperationLog(long inventoryId) {
        return _inventoryRepository.GetOperationLog(inventoryId);
    }
}