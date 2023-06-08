

using ShopManagment.Application.Contracts.ProductCategory;
using System.Linq.Expressions;

namespace ShopManagment.Domains.Agg.ProductCategory;

public interface IProductCategoryRepository
{
    void Create(ProductCategory entity);
    ProductCategory GetBy(long id);
    void Remove(long id);
    void Restore(long id);
    List<ProductCategory> GetAll();
    bool IsExist(Expression<Func<ProductCategory, bool>> ex);
    void SaveChanges();
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel model);
    EditProductCategory GetDetailes(long id);
}