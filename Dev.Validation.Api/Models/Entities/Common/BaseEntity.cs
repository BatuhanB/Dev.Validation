namespace Dev.Validation.Models.Entities.Common;

public abstract class BaseEntity
{
    protected BaseEntity(string id)
    {
        Id = id;
        IsActive= true;
        CreateDate = DateTime.Now;
        UpdateDate = DateTime.Now;
    }

    public string Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsActive { get; set; }
}

