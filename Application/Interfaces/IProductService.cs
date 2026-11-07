using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProductAsync(Product product);
    Task<ApiResponse<bool>> DeleteProductAsync(int id);
    Task<ApiResponse<bool>> UpdateProductAsync(Product product);
    Task<ApiResponse<Product>> GetProductAsync(int id);
    Task<ApiResponse<List<Product>>> GetProducts();
    Task<ApiResponse<List<Product>>> GetProductByCategory(string name);
}
