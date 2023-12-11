using Dev.Validation.Models.Entities;

namespace Dev.Validation.BusinessLogics.Interfaces;

public interface IProductService
{
    Task<bool> Update(Product product);
    Task<bool> Delete(string productId);
    Task<Product> GetById(string productId);
    Task<ICollection<Product>> GetAll();
}

