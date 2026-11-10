using Application.DTOs.Category;
using Application.Responses;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<bool>> AddCategory(CategoryCreateDto category);
    Task<ApiResponse<bool>> DeleteCategory(int id);
    Task<ApiResponse<bool>> UpdateCategory(int id, CategoryUpdateDto category);
    Task<ApiResponse<CategoryResponseDto>> GetCategory(int id);
    Task<ApiResponse<List<CategoryResponseDto>>> GetCategories();
}
