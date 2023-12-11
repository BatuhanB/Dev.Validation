using Dev.Validation.BusinessLogics.Interfaces;
using Dev.Validation.Models.Entities;

namespace Dev.Validation.BusinessLogics.Services;

public class ProductService : IProductService
{
    public List<Product> Products {  get; private set; } = [];
    public ProductService()
    {
        Products.Add(new Product(Guid.NewGuid().ToString(),"Product 1",12,12));
        Products.Add(new Product(Guid.NewGuid().ToString(),"Product 2",23,22));
        Products.Add(new Product(Guid.NewGuid().ToString(),"Product 3",54,32));
        Products.Add(new Product(Guid.NewGuid().ToString(),"Product 4",43,42));
        Products.Add(new Product(Guid.NewGuid().ToString(),"Product 5",12,15));
    }

    public Task<bool> Delete(string productId)
    {
        if (productId == null) return Task.FromResult(false);
        var product = GetById(productId).Result;

        if (product == null) return Task.FromResult(false);
        Products.Remove(product);
        return Task.FromResult(true);
    }

    public async Task<Product> GetById(string productId)
    {
        var product = Products.Find(x=>x.Id == productId);
        if(product == null) return new Product("","",0,0);
        return await Task.FromResult(product);
    }

    public Task<bool> Update(Product product)
    {
        if(product.Id == null) return Task.FromResult(false);
        var productDb = GetById(product.Id).Result;

        if (productDb == null) return Task.FromResult(false); 
        productDb.Name = product.Name;
        productDb.Stock = product.Stock;
        productDb.Price = product.Price;
        productDb.IsActive = product.IsActive;
        productDb.UpdateDate= DateTime.Now;

        return Task.FromResult(true);
    }

    public async Task<ICollection<Product>> GetAll()
    {
        return await Task<ICollection<Product>>.FromResult(Products.ToList());
    }
}
