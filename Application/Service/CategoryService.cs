using System.Net;
using System.Reflection.Metadata.Ecma335;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Infrastructure.Data;

namespace Application.Service;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private ICategoryRepository repository = categoryRepository;
    public async Task<ApiResponse<bool>> AddCategory(Category category)
    {
        if(category == null)
        {
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Category can not null !!");
        }
        var conn = await repository.AddCategory(category);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added !", conn);
    }

    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        if(id <= 0 || id == null)
        {
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "ID is invalid !!");
        }

        var conn = await repository.DeleteCategory(id);

        return conn == true 
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<List<Category>>> GetCategories()
    {
        var conn = await repository.GetCategories();
        return new ApiResponse<List<Category>>(HttpStatusCode.OK, "List of Categories");
    }

    public async Task<ApiResponse<Category>> GetCategory(int id)
    {
        var conn = await repository.GetCategory(id);
        if(conn == null)
        {
            return new ApiResponse<Category>(HttpStatusCode.NotFound, "Category not found!", null!);
        }

        return new ApiResponse<Category>(HttpStatusCode.OK, "Category id. ", conn);
    }

    public async Task<ApiResponse<bool>> UpdateCategory(Category category)
    {
        var conn = await repository.UpdateCategory(category);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Updated!", conn);
    }

}
