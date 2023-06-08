using Framework.OprationRes;

namespace ShopManagment.Application.Contracts.ProductCategory;

public interface IProductCategoryApplication
{
    OprationResult Create(CreateProductCategory command);
    OprationResult Edit(EditProductCategory command);
    EditProductCategory GetDetailes(long id);
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel model);

    OprationResult Remove(long id);
    OprationResult Restore(long id);
}