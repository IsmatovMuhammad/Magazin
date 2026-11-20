using System.Runtime.CompilerServices;
using Application.DTOs.Product;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

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

    [HttpGet("name")]
    public async Task<ApiResponse<List<ProductResponseDto>>> GetProductByCategory(string name)
    {
        return await service.GetProductByCategory(name);
    }

    [HttpGet("Amount product")]
    public async Task<ApiResponse<decimal>> GetAmountOfProducts()
    {
        return await service.GetAmountOfProducts();
    }

    [HttpGet("Amount product by category")]
    public async Task<ApiResponse<bool>> GetAmountOfPtoductsByCategory(string name)
    {
        return await service.GetAmountOfPtoductsByCategory(name);
    }

    [HttpGet("Min price product by category")]
    public async Task<ApiResponse<bool>> GetMinPriceOfProductByCategory(string name)
    {
        return await service.GetMinPriceOfProductByCategory(name);
    }

    [HttpGet("MaxPrice product category")]
    public async Task<ApiResponse<bool>> GetMaxPriceOfProductByCategory(string name)
    {
        return await service.GetMaxPriceOfProductByCategory(name);
    }

    [HttpGet("Average price product by category")]
    public async Task<ApiResponse<bool>> GetAveragePriceOfProductbyCategory(string name)
    {
        return await service.GetAveragePriceOfProductbyCategory(name);
    }

    [HttpGet("Total price product")]
    public async Task<ApiResponse<decimal>> GetTotalPriceOfProducts()
    {
        return await service.GetTotalPriceOfProducts();
    }
}
