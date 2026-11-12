using System.Net;
using System.Reflection.Metadata.Ecma335;
using Application.DTOs.Category;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Application.Service;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private ICategoryRepository repository = categoryRepository;
    public async Task<ApiResponse<bool>> AddCategory(CategoryCreateDto category)
    {
        var categ = new Category()
        {
            Name = category.Name
        };
        var res = await repository.AddCategory(categ);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Category added !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Category not added !");
    }

    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        var conn = await repository.DeleteCategory(id);

        return conn == true 
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<List<CategoryResponseDto>>> GetCategories()
    {
        var cate = await repository.GetCategories();
        var category = cate.Select(s => new CategoryResponseDto
        {
            Id = s.Id,
            Name = s.Name
        }).ToList();
        return new ApiResponse<List<CategoryResponseDto>>(HttpStatusCode.OK, "List of Category", category);
    }

    public async Task<ApiResponse<CategoryResponseDto>> GetCategory(int id)
    {
        var conn = await repository.GetCategory(id);
        var category = new CategoryResponseDto
        {
            Id = id,
            Name = conn.Name
        };
        return new ApiResponse<CategoryResponseDto>(HttpStatusCode.OK, "Category by id. ", category);
    }

    public async Task<ApiResponse<bool>> UpdateCategory(int id, CategoryUpdateDto category)
    {
        var cate = new Category()
        {
            Name = category.Name
        };
        var res = await repository.UpdateCategory(cate);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Category update !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Category not update !");
    }
}
