using DiscountManagment.Application.Contracts.ColleagueDiscount;
using DiscountManagment.Domains.Agg.ColleagueDiscount;
using DiscountManagment.Infrastructure.EFCore.Context;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.EFCore.Context;

namespace DiscountManagment.Infrastructure.EFCore.Repositories;

public class ColleagueDiscountRepository : BaseRepository<long, ColleagueDiscount>, IColleagueDiscountRepository {
    private readonly DiscountDbContext _context;
    private readonly ShopDbContext _shopContext;

    public ColleagueDiscountRepository(DiscountDbContext context, ShopDbContext shopContext) : base(context)
    {
        _context = context;
        _shopContext = shopContext;
    }

    public EditColleagueDiscount? GetDetails(long id) {
        return _context.ColleagueDiscounts.Select(x => new EditColleagueDiscount {
            Id = x.Id,
            DiscountRate = x.DiscountRate,
            ProductId = x.ProductId
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel) {
        var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
        var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel {
            Id = x.Id,
            CreationDate = x.CreatedDate,
            DiscountRate = x.DiscountRate,
            ProductId = x.ProductId,
            IsRemoved = x.IsRemove
        });

        if (searchModel.ProductId > 0)
            query = query.Where(x => x.ProductId == searchModel.ProductId);

        var discounts = query.OrderByDescending(x => x.Id).ToList();
        discounts.ForEach(discount =>
            discount.ProductName = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
        return discounts;
    }
}