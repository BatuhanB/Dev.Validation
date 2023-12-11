using Dev.Validation.Models.Entities.Common;

namespace Dev.Validation.Models.Entities;

// Primary Constructor
public class Product(string id,
    string name,
    int stock,
    double price) : BaseEntity(id)
{
    public string Name { get; set; } = name;
    public int Stock { get; set; } = stock;
    public double Price { get; set; } = price;
}
