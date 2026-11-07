using System.Runtime.CompilerServices;
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
    public async Task<ApiResponse<List<Product>>> GetProducts()
    {
        return await service.GetProducts();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(Product product)
    {
        return await service.AddProductAsync(product);
    }
    
    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        return await service.DeleteProductAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(Product product)
    {
        return await service.UpdateProductAsync(product);
    }

    [HttpGet("{id:int}")] 
    public async Task<ApiResponse<Product>> GetProduct(int id)
    {
        return await service.GetProductAsync(id);
    }

    [HttpGet("{name}")]
    public async Task<ApiResponse<List<Product>>> GetProductByCategory(string name)
    {
        return await service.GetProductByCategory(name);
    }
}
