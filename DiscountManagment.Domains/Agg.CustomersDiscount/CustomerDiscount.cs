using Framework.SharedDomain;

namespace DiscountManagment.Domains.Agg.CustomersDiscount;

public class CustomerDiscount : BaseEntity
{
    public long ProductId { get; private set; }
    public int DiscountRate { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string? Reason { get; private set; }


    public CustomerDiscount(long productId, int discountRate, DateTime startDate,
        DateTime endDate, string? reason)
    {
        ProductId = productId;
        DiscountRate = discountRate;
        StartDate = startDate;
        EndDate = endDate;
        Reason = reason;
        IsRemove = false;
    }

    public void Edit(long productId, int discountRate, DateTime startDate,
        DateTime endDate, string? reason)
    {
        ProductId = productId;
        DiscountRate = discountRate;
        StartDate = startDate;
        EndDate = endDate;
        Reason = reason;
    }

    public void Remove()
    {
        IsRemove = true;
    }
    public void Restore()
    {
        IsRemove = false;
    }
}