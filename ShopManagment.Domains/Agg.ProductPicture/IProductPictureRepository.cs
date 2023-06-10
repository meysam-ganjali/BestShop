using Framework.IGenericRepository;
using ShopManagment.Application.Contracts.ProductPicture;

namespace ShopManagment.Domains.Agg.ProductPicture;

public interface IProductPictureRepository:IRepository<long,ProductPicture>
{
    EditProductPicture? GetDetailes(long id);
    List<ProductPictureViewModel> Search(ProductPictureSearchModel model);
}