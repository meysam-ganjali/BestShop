using Framework.IGenericRepository;
using ShopManagment.Application.Contracts.Product;

namespace ShopManagment.Domains.Agg.Product;

public interface IProductRepository:IRepository<long,Product>
{
    List<ProductViewModel> Search(ProductSearchModel model);
    EditProduct? GetDetailes(long id);
}