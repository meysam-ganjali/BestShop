using System.Linq.Expressions;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Domains.Agg.ProductCategory;
using ShopManagment.Infrastructure.EFCore.Context;

namespace ShopManagment.Infrastructure.EFCore.Repositories;

public class ProductCategoryRepository : BaseRepository<long,ProductCategory>,IProductCategoryRepository {
    private readonly ShopDbContext _context;

    public ProductCategoryRepository(ShopDbContext context) :base(context){
        _context = context;
    }

    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel model)
    {
        var query = _context.ProductCategories
            .Include(x=>x.Products)
            .Select(x => new ProductCategoryViewModel()
        {
            Name = x.Name,
            CreatedDate = x.CreatedDate,
            Id = x.Id,
            IsRemoveed = x.IsRemove,
            Picture = x.Picture,
            ProductInThis = x.Products.Count
        });
        if (!string.IsNullOrWhiteSpace(model.Name))
            query = query.Where(x => x.Name.Contains(model.Name));
        return query.OrderByDescending(x=>x.Id).ToList();
    }

    public EditProductCategory? GetDetailes(long id) {
        return _context.ProductCategories.Select(x => new EditProductCategory() {
            Id = x.Id,
            Des = x.Des,
            KeyWord = x.KeyWord,
            MetaDes = x.MetaDes,
            Name = x.Name,
            Picture = x.Picture,
            Slug = x.Slug,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle
        }).FirstOrDefault(x => x.Id == id);
    }
    public List<ProductCategoryViewModel> GetProductCategories() {
        return _context.ProductCategories.Select(x => new ProductCategoryViewModel {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }

}