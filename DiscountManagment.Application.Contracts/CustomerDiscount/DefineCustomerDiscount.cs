using Framework.Validation;
using ShopManagment.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagment.Application.Contracts.CustomerDiscount;

public class DefineCustomerDiscount
{
    [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
    public long ProductId { get; set; }

    [Range(1, 99, ErrorMessage = ValidationMessages.IsRequired)]
    public int DiscountRate { get; set; }

    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public DateTime EndDate { get; set; }

    public string? Reason { get; set; }
    public List<ProductViewModel> Products { get; set; }
}