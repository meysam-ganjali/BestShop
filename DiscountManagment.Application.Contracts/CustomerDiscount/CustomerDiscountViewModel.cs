﻿namespace DiscountManagment.Application.Contracts.CustomerDiscount;

public class CustomerDiscountViewModel {
    public long Id { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public int DiscountRate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsRemoved { get; set; }
}