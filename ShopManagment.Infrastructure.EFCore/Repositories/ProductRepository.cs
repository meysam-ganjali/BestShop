using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Domains.Agg.Product;
using ShopManagment.Infrastructure.EFCore.Context;

namespace ShopManagment.Infrastructure.EFCore.Repositories;

public class ProductRepository : BaseRepository<long, Product>, IProductRepository {
    private readonly ShopDbContext _context;

    public ProductRepository(ShopDbContext context) : base(context) {
        _context = context;
    }
    public List<ProductViewModel> Search(ProductSearchModel model) {
        var query = _context.Products.Include(x => x.Category)
            .Select(x => new ProductViewModel() {
                Name = x.Name,
                Picture = x.Picture,
                CategoryName = x.Category.Name,
                CategoryId = x.Category.Id,
                Code = x.Code,
                Id = x.Id,
                UnitPraice = x.UnitPraice,
                IsRemoved = x.IsRemove,
                StockStatus = x.IsInStock
        });
        if (!string.IsNullOrWhiteSpace(model.Name))
            query = query.Where(x => x.Name.Contains(model.Name));
        if (!string.IsNullOrWhiteSpace(model.Code))
            query = query.Where(x => x.Name.Equals(model.Code));
        if (model.CategoryId > 0)
            query = query.Where(x => x.CategoryId == model.CategoryId);
        return query.OrderByDescending(x=>x.Id).ToList();
    }

    public EditProduct? GetDetailes(long id) {
        return _context.Products.Select(x => new EditProduct {
            Code = x.Code,
            Id = x.Id,
            UnitPraice = x.UnitPraice,
            CategoryId = x.CategoryId,
            Description = x.Description,
            IsInStock = x.IsInStock,
            Keywords = x.Keywords,
            MetaDescription = x.MetaDescription,
            Name = x.Name,
            Picture = x.Picture,
            Slug = x.Slug,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            ShortDescription = x.ShortDescription,
        }).FirstOrDefault();
    }
}