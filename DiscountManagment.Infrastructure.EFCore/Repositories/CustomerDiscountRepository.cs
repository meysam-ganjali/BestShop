using DiscountManagment.Application.Contracts.CustomerDiscount;
using DiscountManagment.Domains.Agg.CustomersDiscount;
using DiscountManagment.Infrastructure.EFCore.Context;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.EFCore.Context;

namespace DiscountManagment.Infrastructure.EFCore.Repositories;

public class CustomerDiscountRepository:BaseRepository<long,CustomerDiscount>,ICustomerDiscountRepository
{
    private readonly DiscountDbContext _discountcontext;
    private readonly ShopDbContext _shopContext;

    public CustomerDiscountRepository( DiscountDbContext discountcontext, ShopDbContext shopContext) : base(discountcontext)
    {
        _discountcontext = discountcontext;
        _shopContext = shopContext;
    }

    public EditCustoemrDiscount? GetDetails(long id)
    {
        return _discountcontext.CustomerDiscounts.Select(x => new EditCustoemrDiscount()
        {
            DiscountRate = x.DiscountRate,
            EndDate = x.EndDate,
            Id = x.Id,
            ProductId = x.ProductId,
            Reason = x.Reason,
            StartDate = x.StartDate,
            
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
    {
        var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
        var query = _discountcontext.CustomerDiscounts.Select(x => new CustomerDiscountViewModel()
        {
            DiscountRate = x.DiscountRate,
            EndDate = x.EndDate,
            Id = x.Id,
            ProductId = x.ProductId,
            Reason = x.Reason,
            StartDate = x.StartDate,
            CreationDate = x.CreatedDate,
            ProductName = "",
            IsRemoved = x.IsRemove
        });
        if (searchModel.ProductId != 0 || searchModel.ProductId > 0)
            query = query.Where(x => x.ProductId == searchModel.ProductId);
        if (searchModel.StartDate != null)
            query = query.Where(x => x.StartDate > searchModel.StartDate);
        if (searchModel.EndDate != null)
            query = query.Where(x => x.EndDate < searchModel.EndDate);

        var discounts = query.OrderByDescending(x => x.Id).ToList();

        discounts.ForEach(discount => discount.ProductName = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
        return discounts;
    }
}