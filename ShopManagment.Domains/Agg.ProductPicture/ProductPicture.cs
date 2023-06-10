using Framework.SharedDomain;
namespace ShopManagment.Domains.Agg.ProductPicture;

public class ProductPicture:BaseEntity
{
    public string Picture { get; private set; }
    public long ProductId { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public Product.Product Product{ get; private set; }

    public ProductPicture(string picture, long productId, string pictureAlt, string pictureTitle)
    {
        Picture = picture;
        ProductId = productId;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        IsRemove = false;
        CreatedDate = DateTime.Now;
    }
    public void Edit(string picture, long productId, string pictureAlt, string pictureTitle) {
        Picture = picture;
        ProductId = productId;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
    }

    public void Remove()
    {
        IsRemove = true;
    }
    public void Restore() {
        IsRemove = false;
    }
}