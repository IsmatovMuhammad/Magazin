using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class ProductsService(IProductsRepository productsRepository) : IProductService
{
    private IProductsRepository repository = productsRepository;
    public async Task<ApiResponse<bool>> AddProductAsync(Product product)
    {
        if(product == null)
        {
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Product can not null !");
        }
        var conn = await repository.AddProductAsync(product);
        return conn == true 
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added !", conn);
    }

    public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
    {
        if(id <= 0 || id == null)
        {
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "ID is invalid !!");
        }
        var conn = await repository.DeleteProductAsync(id);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<Product>> GetProductAsync(int id)
    {
        var conn = await repository.GetProductAsync(id);
        if(conn == null)
        {
            return new ApiResponse<Product>(HttpStatusCode.NotFound, "Not Found", null!);
        }
        return new ApiResponse<Product>(HttpStatusCode.OK, "Product id. ", conn);
    }

    public async Task<ApiResponse<List<Product>>> GetProductByCategory(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new ApiResponse<List<Product>>(HttpStatusCode.BadRequest, "Name is invalid !");
        }
        var conn = await repository.GetProductByCategory(name);
        if(conn == null || !conn.Any())
        {
            return new ApiResponse<List<Product>>(HttpStatusCode.NotFound, "Not found !", null!);
        }
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "Product by Category.", conn);
    }

    public async Task<ApiResponse<List<Product>>> GetProducts()
    {
        var conn = await repository.GetProducts();
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "List of Products. ", conn);
    }

    public async Task<ApiResponse<bool>> UpdateProductAsync(Product product)
    {
        var conn = await repository.UpdateProductAsync(product);
        return conn == true 
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Updated !", conn);
    }

}