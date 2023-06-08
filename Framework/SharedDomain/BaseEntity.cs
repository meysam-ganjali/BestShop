namespace Framework.SharedDomain;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsRemove { get; set; }

    public BaseEntity()
    {
        CreatedDate= DateTime.Now;
        IsRemove = false;
    }
}