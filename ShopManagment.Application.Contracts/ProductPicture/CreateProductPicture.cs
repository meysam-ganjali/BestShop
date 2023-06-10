
using Framework.Validation;
using ShopManagment.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contracts.ProductPicture;

public class CreateProductPicture
{
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Picture { get;  set; }

    public long ProductId { get;  set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]

    public string PictureAlt { get;  set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]

    public string PictureTitle { get;  set; }
    public bool IsRemoved { get; set; }
    public List<ProductViewModel> Products { get; set; }
}