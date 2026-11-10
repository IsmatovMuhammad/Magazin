using System.Formats.Asn1;
using Application.DTOs.Category;
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
    public async Task<ApiResponse<List<CategoryResponseDto>>> GetCategories()
    {
        return await service.GetCategories();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CategoryCreateDto category)
    {
        return await service.AddCategory(category);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        return await service.DeleteCategory(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCAtegory(int id, CategoryUpdateDto category)
    {
        return await service.UpdateCategory(id, category);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CategoryResponseDto>> GetCategory(int id)
    {
        return await service.GetCategory(id);
    }
}
