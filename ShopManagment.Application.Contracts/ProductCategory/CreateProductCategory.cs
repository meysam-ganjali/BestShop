using Framework.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contracts.ProductCategory;

public class CreateProductCategory
{
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Name { get;  set; }
    //[FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
    //[MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
    public string? Picture { get;  set; }
    public string? PictureAlt { get;  set; }
    public string? PictureTitle { get;  set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string MetaDes { get;  set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string KeyWord { get;  set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Slug { get;  set; }
    public string? Des { get;  set; }
}