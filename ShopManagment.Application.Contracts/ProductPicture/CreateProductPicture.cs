namespace ShopManagment.Application.Contracts.ProductPicture;

public class CreateProductPicture
{
    public string Picture { get;  set; }
    public long ProductId { get;  set; }
    public string PictureAlt { get;  set; }
    public string PictureTitle { get;  set; }
    public bool IsRemoved { get; set; }
}