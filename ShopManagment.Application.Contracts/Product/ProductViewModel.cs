namespace ShopManagment.Application.Contracts.Product;

public class ProductViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public long UnitPraice { get; set; }
    public string CategoryName { get; set; }
    public string Picture { get; set; }
    public long CategoryId { get; set; }
    public bool IsRemoved { get; set; }
    public bool StockStatus { get; set; }
}