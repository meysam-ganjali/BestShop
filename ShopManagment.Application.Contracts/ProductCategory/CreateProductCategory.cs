namespace ShopManagment.Application.Contracts.ProductCategory;

public class CreateProductCategory
{
    public string Name { get;  set; }
    public string? Picture { get;  set; }
    public string? PictureAlt { get;  set; }
    public string? PictureTitle { get;  set; }
    public string MetaDes { get;  set; }
    public string KeyWord { get;  set; }
    public string Slug { get;  set; }
    public string? Des { get;  set; }
}