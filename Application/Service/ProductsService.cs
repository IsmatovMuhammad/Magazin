using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Application.DTOs.Product;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class ProductsService(IProductsRepository productsRepository) : IProductService
{
    private IProductsRepository repository = productsRepository;
    public async Task<ApiResponse<bool>> AddProductAsync(ProductCreateDto product)
    {
        var produc = new Product()
        {
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
        var res = await repository.AddProductAsync(produc);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Product added !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Product not added !");
    }

    public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
    {
        var conn = await repository.DeleteProductAsync(id);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<ProductResponseDto>> GetProductAsync(int id)
    {
        var product = await repository.GetProductAsync(id);
        var p = new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
        return new ApiResponse<ProductResponseDto>(HttpStatusCode.OK, "Product by id. ", p);
    }

    public async Task<ApiResponse<List<ProductResponseDto>>> GetProductByCategory(string name)
    {
        var con = await repository.GetProductByCategory(name);
        var pr = con.Select(s => new ProductResponseDto
        {
            Name = s.Name,
            Price = s.Price,
            CategoryId = s.CategoryId
        }).ToList();
        return new ApiResponse<List<ProductResponseDto>>(HttpStatusCode.OK, "List product by category. ", pr);
    }

    public async Task<ApiResponse<List<ProductResponseDto>>> GetProducts()
    {
        var conn = await repository.GetProducts();
        var product = conn.Select(s => new ProductResponseDto
        {
            Name = s.Name,
            Price = s.Price,
            CategoryId = s.CategoryId
        }).ToList();
        return new ApiResponse<List<ProductResponseDto>>(HttpStatusCode.OK, "List of Product. ", product);
    }

    public async Task<ApiResponse<bool>> UpdateProductAsync(int id, ProductUpdateDto product)
    {
        var pr = new Product()
        {
            Id = id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
        var conn = await repository.UpdateProductAsync(pr);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Product updated !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Product not update !");
    }
}