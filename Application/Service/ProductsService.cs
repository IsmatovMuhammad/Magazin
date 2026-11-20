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

    public async Task<ApiResponse<decimal>> GetAmountOfProducts()
    {
        var conn = await repository.GetAmountOfProducts();
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Amount proucts", conn);
    }

    public async Task<ApiResponse<bool>> GetAmountOfPtoductsByCategory(string name)
    {
        var conn = await repository.GetAmountOfPtoductsByCategory(name);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Amount product by category", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Amount not found");
    }

    public async Task<ApiResponse<bool>> GetAveragePriceOfProductbyCategory(string name)
    {
        var res = await repository.GetAveragePriceOfProductbyCategory(name);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Average price product by category", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not found");
    }

    public async Task<ApiResponse<bool>> GetMaxPriceOfProductByCategory(string name)
    {
        var res = await repository.GetMaxPriceOfProductByCategory(name);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Max price product by category", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not found");
    }

    public async Task<ApiResponse<bool>> GetMinPriceOfProductByCategory(string name)
    {
        var res = await repository.GetMinPriceOfProductByCategory(name);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Min price product by category", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not found");
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
            Id = s.Id,
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
            Id = s.Id,
            Name = s.Name,
            Price = s.Price,
            CategoryId = s.CategoryId
        }).ToList();
        return new ApiResponse<List<ProductResponseDto>>(HttpStatusCode.OK, "List of Product. ", product);
    }

    public async Task<ApiResponse<decimal>> GetTotalPriceOfProducts()
    {
        var res = await repository.GetTotalPriceOfProducts();
        return new ApiResponse<decimal>(HttpStatusCode.OK, "total price product", res);
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
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Product updated !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Product not update !");
    }
}