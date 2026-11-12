using System.Runtime.CompilerServices;
using Application.DTOs.Product;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController(
    IProductService productService,
    ILogger<ProductController> logger
    ) : Controller
{
    private IProductService service = productService;
    private ILogger<ProductController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<ProductResponseDto>>> GetProducts()
    {
        _logger.LogInformation("List of Product {Time}", DateTime.Now);
        return await service.GetProducts();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(ProductCreateDto product)
    {
        _logger.LogInformation("Product added {Time}", DateTime.Now);
        return await service.AddProductAsync(product);
    }
    
    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        _logger.LogInformation("Product deleted {Time}", DateTime.Now);
        return await service.DeleteProductAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(int id, ProductUpdateDto product)
    {
        _logger.LogInformation("Product updated {Time}", DateTime.Now);
        return await service.UpdateProductAsync(id, product);
    }

    [HttpGet("{id:int}")] 
    public async Task<ApiResponse<ProductResponseDto>> GetProduct(int id)
    {
        _logger.LogInformation("Product by id {Time}", DateTime.Now);
        return await service.GetProductAsync(id);
    }

    [HttpGet("{name}")]
    public async Task<ApiResponse<List<ProductResponseDto>>> GetProductByCategory(string name)
    {
        _logger.LogInformation("Product by name {Time}", DateTime.Now);
        return await service.GetProductByCategory(name);
    }
}
