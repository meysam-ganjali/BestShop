using Framework.OprationRes;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Domains.Agg.ProductPicture;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagment.Application.Services;

public class ProductPictureApplication:IProductPictureApplication
{
    private readonly IProductPictureRepository _productPictureRepository;

    public ProductPictureApplication(IProductPictureRepository productPictureRepository)
    {
        _productPictureRepository = productPictureRepository;
    }
    public OprationResult Create(CreateProductPicture command)
    {
        OprationResult op=new OprationResult();
        var productPicture =
            new ProductPicture(command.Picture, command.ProductId, command.PictureAlt, command.PictureTitle);
        _productPictureRepository.Add(productPicture);
        _productPictureRepository.SaveChanges();
        return op.Successed("تصویر با گالری محصول با موفقیت اضافه شد");
    }

    public OprationResult Edit(EditProductPicture command)
    {
        OprationResult op = new OprationResult();
        var productPicture = _productPictureRepository.Get(command.Id);
        if (productPicture == null)
            return op.Failed("تصویر مورد نظر یافت نشد");
        productPicture.Edit(command.Picture,command.ProductId,command.PictureAlt,command.PictureTitle);
        _productPictureRepository.SaveChanges();
        return op.Successed("عملیات بروزرسانی گالری محصول با موفقیت به اتمام رسید");
    }

    public List<ProductPictureViewModel> Search(ProductPictureSearchModel model)
    {
        return _productPictureRepository.Search(model);
    }

    public EditProductPicture? GetDetailes(long id)
    {
        return _productPictureRepository.GetDetailes(id);
    }

    public OprationResult Remove(long id)
    {
        OprationResult op = new OprationResult();
        var productPicture = _productPictureRepository.Get(id);
        if (productPicture == null)
            return op.Failed("تصویر مورد نظر یافت نشد");
        productPicture.Remove();
        _productPictureRepository.SaveChanges();
        return op.Successed();
    }

    public OprationResult Restore(long id)
    {
        OprationResult op = new OprationResult();
        var productPicture = _productPictureRepository.Get(id);
        if (productPicture == null)
            return op.Failed("تصویر مورد نظر یافت نشد");
        productPicture.Restore();
        _productPictureRepository.SaveChanges();
        return op.Successed();
    }
}