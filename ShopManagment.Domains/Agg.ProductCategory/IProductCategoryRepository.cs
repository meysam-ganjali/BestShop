

using ShopManagment.Application.Contracts.ProductCategory;
using Framework.IGenericRepository;

namespace ShopManagment.Domains.Agg.ProductCategory;

public interface IProductCategoryRepository:IRepository<long,ProductCategory>
{
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel model);
    EditProductCategory? GetDetailes(long id);
}