using System.Formats.Asn1;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoryController(ICategoryService categoryService) : Controller
{
    private ICategoryService service = categoryService;
    
    [HttpGet]
    public async Task<ApiResponse<List<Category>>> GetCategories()
    {
        return await service.GetCategories();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(Category category)
    {
        return await service.AddCategory(category);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        return await service.DeleteCategory(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCAtegory(Category category)
    {
        return await service.UpdateCategory(category);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Category>> GetCategory(int id)
    {
        return await service.GetCategory(id);
    }
}
