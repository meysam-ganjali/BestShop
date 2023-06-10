
using Framework.SharedDomain;

namespace ShopManagment.Domains.Agg.ProductCategory;
public class ProductCategory:BaseEntity 
{
    public string Name { get; private set; }
    public string? Picture { get; private set; }
    public string? PictureAlt { get; private set; }
    public string? PictureTitle { get; private set; }
    public string MetaDes { get; private set; }
    public string KeyWord { get; private set; }
    public string Slug { get; private set; }
    public string? Des { get; private set; }
    public List<Product.Product> Products { get; private set; }

    public ProductCategory()
    {
        Products = new List<Product.Product>();
    }
    public ProductCategory(string name, string? picture, string? pictureAlt, string? pictureTitle, string metaDes, string keyWord, string slug, string? des) {
        Name = name;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        MetaDes = metaDes;
        KeyWord = keyWord;
        Slug = slug;
        Des = des;
    }
    public void Edit(string name, string? picture, string? pictureAlt, string? pictureTitle, string metaDes, string keyWord, string slug, string? des) {
        Name = name;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        MetaDes = metaDes;
        KeyWord = keyWord;
        Slug = slug;
        Des = des;
    }
}