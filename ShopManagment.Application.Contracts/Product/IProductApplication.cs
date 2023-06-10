using Framework.OprationRes;

namespace ShopManagment.Application.Contracts.Product;

public interface IProductApplication
{
    OprationResult Create(CreateProduct command);
    OprationResult Edit(EditProduct command);
    EditProduct? GetDetailes(long id);
    OprationResult IsInStock(long id);
    OprationResult NotInStock(long id);
    List<ProductViewModel> Search(ProductSearchModel model);
    List<ProductViewModel> GetProducts();
    OprationResult Remove(long id);
    OprationResult Restore(long id);
}