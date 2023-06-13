using Framework.Infrastructure;
using InventoryManagment.Application.Contracts.Inventory;
using InventoryManagment.Domains.Agg.Inventory;
using InventoryManagment.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.EFCore.Context;

namespace InventoryManagment.Infrastructure.EFCore.Repositories;

public class InventoryRepository:BaseRepository<long,Inventory>,IInventoryRepository
{
    private readonly InventoryDbContext _context;
    private readonly ShopDbContext _shopContext;

    public InventoryRepository(InventoryDbContext context, ShopDbContext shopContext) : base(context)
    {
        _context = context;
        _shopContext = shopContext;
    }

    public EditInventory? GetDetails(long id)
    {
        return _context.Inventory.Select(x => new EditInventory()
        {
            Id = x.Id,
            ProductId = x.ProductId,
            UnitPrice = x.UnitPrice
        }).FirstOrDefault(x => x.Id == id);
    }

    public Inventory GetBy(long productId)
    {
        return _context.Inventory.FirstOrDefault(x => x.ProductId == productId);
    }

    public List<InventoryViewModel> Search(InventorySearchModel searchModel)
    {
        var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
        var query = _context.Inventory.Select(x => new InventoryViewModel
        {
            Id = x.Id,
            ProductId = x.ProductId,
            UnitPrice = x.UnitPrice,
            CreationDate = x.CreatedDate,
            InStock = x.InStock,
            CurrentCount = x.CalculateCurrentCount(),
        });
        if (searchModel.ProductId > 0 || searchModel.ProductId != 0)
            query = query.Where(x => x.ProductId == searchModel.ProductId);
        var inventory = query.OrderByDescending(x => x.Id).ToList();

        inventory.ForEach(item =>
            item.ProductName = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name);

        return inventory;
    }
    public List<InventoryOperationViewModel> GetOperationLog(long inventoryId) {
     
        var inventory = _context.Inventory.FirstOrDefault(x => x.Id == inventoryId);
        var operations = inventory.Operations.Select(x => new InventoryOperationViewModel {
            Id = x.Id,
            Count = x.Count,
            CurrentCount = x.CurrentCount,
            Description = x.Description,
            Operation = x.Operation,
            OperationDate = x.OperationDate,
            OperatorId = 1,
            OrderId = 1
        }).OrderByDescending(x => x.Id).ToList();


        return operations;
    }
}