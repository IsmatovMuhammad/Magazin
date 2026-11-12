using System.Formats.Asn1;
using Application.DTOs.Category;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoryController(
    ICategoryService categoryService,
    ILogger<CategoryController> logger
    ) : Controller
{
    private ICategoryService service = categoryService;
    private ILogger<CategoryController> _logger = logger;
    
    [HttpGet]
    public async Task<ApiResponse<List<CategoryResponseDto>>> GetCategories()
    {
        _logger.LogInformation("List of Category {Time}", DateTime.Now);
        return await service.GetCategories();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CategoryCreateDto category)
    {
        _logger.LogInformation("Category added {Time}", DateTime.Now);
        return await service.AddCategory(category);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        _logger.LogInformation("Category deleted {Time}", DateTime.Now);
        return await service.DeleteCategory(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCAtegory(int id, CategoryUpdateDto category)
    {
        _logger.LogInformation("Category updated {Time}", DateTime.Now);
        return await service.UpdateCategory(id, category);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CategoryResponseDto>> GetCategory(int id)
    {
        _logger.LogInformation("Category by id {Time}", DateTime.Now);
        return await service.GetCategory(id);
    }
}
