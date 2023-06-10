using Framework.IGenericRepository;
using ShopManagment.Application.Contracts.Product;

namespace ShopManagment.Domains.Agg.Product;

public interface IProductRepository:IRepository<long,Product>
{
    List<ProductViewModel> Search(ProductSearchModel model);
    List<ProductViewModel> GetProducts();
    EditProduct? GetDetailes(long id);


}