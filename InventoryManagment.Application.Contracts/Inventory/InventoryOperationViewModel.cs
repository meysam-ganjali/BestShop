﻿namespace InventoryManagment.Application.Contracts.Inventory;

public class InventoryOperationViewModel {
    public long Id { get; set; }
    public bool Operation { get; set; }
    public long Count { get; set; }
    public long OperatorId { get; set; }
    public string Operator { get; set; }
    public DateTime OperationDate { get; set; }
    public long CurrentCount { get; set; }
    public string Description { get; set; }
    public long OrderId { get; set; }
}