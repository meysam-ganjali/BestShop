namespace ShopManagment.Application.Contracts.ProductCategory;

public class ProductCategoryViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Picture { get; set; }
    public bool IsRemoveed { get; set; }
    public long ProductInThis { get; set; }
    public DateTime CreatedDate { get; set; }
}