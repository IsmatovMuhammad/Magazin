using System.Runtime.CompilerServices;
using Application.DTOs.Product;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController(IProductService productService) : Controller
{
    private IProductService service = productService;

    [HttpGet]
    public async Task<ApiResponse<List<ProductResponseDto>>> GetProducts()
    {
        return await service.GetProducts();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(ProductCreateDto product)
    {
        return await service.AddProductAsync(product);
    }
    
    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        return await service.DeleteProductAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(int id, ProductUpdateDto product)
    {
        return await service.UpdateProductAsync(id, product);
    }

    [HttpGet("{id:int}")] 
    public async Task<ApiResponse<ProductResponseDto>> GetProduct(int id)
    {
        return await service.GetProductAsync(id);
    }

    [HttpGet("{name}")]
    public async Task<ApiResponse<List<ProductResponseDto>>> GetProductByCategory(string name)
    {
        return await service.GetProductByCategory(name);
    }
}
