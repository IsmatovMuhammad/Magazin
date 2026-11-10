using Application.DTOs.Product;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProductAsync(ProductCreateDto product);
    Task<ApiResponse<bool>> DeleteProductAsync(int id);
    Task<ApiResponse<bool>> UpdateProductAsync(int id, ProductUpdateDto product);
    Task<ApiResponse<ProductResponseDto>> GetProductAsync(int id);
    Task<ApiResponse<List<ProductResponseDto>>> GetProducts();
    Task<ApiResponse<List<ProductResponseDto>>> GetProductByCategory(string name);
}
