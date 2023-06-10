using Framework.SharedDomain;

namespace ShopManagment.Domains.Agg.Product;

public class Product : BaseEntity {


    public string Name { get; private set; }
    public long UnitPraice { get; set; }
    public string? Code { get; private set; }
    public string ShortDescription { get; private set; }
    public string Description { get; private set; }
    public string Picture { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public long CategoryId { get; private set; }
    public string Slug { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public bool IsInStock { get; private set; }
    public ProductCategory.ProductCategory Category { get; private set; }
    public List<ProductPicture.ProductPicture> ProductPictures { get; private set; }

    public Product()
    {
        ProductPictures = new List<ProductPicture.ProductPicture>();
    }
    public Product(string name, long unitPraice, string code, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, long categoryId, string slug, string keywords, string metaDescription) {
        Name = name;
        UnitPraice = unitPraice;
        Code = code;
        ShortDescription = shortDescription;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        CategoryId = categoryId;
        Slug = slug;
        Keywords = keywords;
        MetaDescription = metaDescription;
        IsInStock = true;
    }
    public void Edit(string name, long unitPraice, string code, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, long categoryId, string slug, string keywords, string metaDescription) {
        Name = name;
        UnitPraice = unitPraice;
        Code = code;
        ShortDescription = shortDescription;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        CategoryId = categoryId;
        Slug = slug;
        Keywords = keywords;
        MetaDescription = metaDescription;
    }

    public void InStock() {
        this.IsInStock = true;
    }
    public void NotingInStock() {
        this.IsInStock = false;
    }

    public void Remove()
    {
        IsRemove = true;
    }
    public void Restore() {
        IsRemove = false;
    }
}