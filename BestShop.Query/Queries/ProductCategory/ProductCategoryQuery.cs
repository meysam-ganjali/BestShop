using BestShop.Query.Contracts.ProductCategory;
using ShopManagment.Infrastructure.EFCore.Context;

namespace BestShop.Query.Queries.ProductCategory;

public class ProductCategoryQuery:IProductCategoryQuery
{
    private readonly ShopDbContext _shopDbContext;

    public ProductCategoryQuery(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public List<SiteProductCategoryViewModel> GetAllCategory()
    {
        return _shopDbContext.ProductCategories.Where(x => x.IsRemove == false)
            .Select(x => new SiteProductCategoryViewModel()
            {
                Des = x.Des,
                Id = x.Id,
                Picture = x.Picture,
                KeyWord = x.KeyWord,
                MetaDes = x.MetaDes,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
            }).ToList();
    }
}