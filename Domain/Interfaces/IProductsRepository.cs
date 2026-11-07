using Domain.Models;

namespace Domain.Interfaces;

public interface IProductsRepository
{
    Task<bool> AddProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> UpdateProductAsync(Product product);
    Task<Product> GetProductAsync(int id);
    Task<List<Product>> GetProducts();
    Task<List<Product>> GetProductByCategory(string name);
}
