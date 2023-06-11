namespace BestShop.Query.Contracts.ProductCategory;

public interface IProductCategoryQuery
{
    List<SiteProductCategoryViewModel> GetAllCategory();
}