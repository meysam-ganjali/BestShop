using Framework.OprationRes;

namespace ShopManagment.Application.Contracts.ProductPicture;

public interface IProductPictureApplication
{
    OprationResult Create(CreateProductPicture command);
    OprationResult Edit(EditProductPicture command);
    List<ProductPictureViewModel> Search(ProductPictureSearchModel model);
    EditProductPicture? GetDetailes(long id);
    OprationResult Remove(long id);
    OprationResult Restore(long id);
}