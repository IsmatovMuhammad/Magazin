using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Repository;

public class ProductRepository(DataBase dataBase) : IProductsRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddProductAsync(Product product)
    {
        data.Products.Add(product);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }


    public async Task<bool> DeleteProductAsync(int id)
    {
        var del = await data.Products.FirstOrDefaultAsync(x => x.Id == id);
        if(del != null)
        {
            data.Products.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<decimal> GetAmountOfProducts()
    {
        return await data.Products.SumAsync(x => x.Price);
        
    }

    public async Task<bool> GetAmountOfPtoductsByCategory(string name)
    {
        var res = await data.Products.Where(x => x.Category.Name == name)
        .SumAsync(x => x.Price);
        return res > 0;

    }

    public async Task<bool> GetAveragePriceOfProductbyCategory(string name)
    {
        var res = await data.Products.Where(x => x.Category.Name == name)
        .AverageAsync(x => x.Price);
        return res > 0;
    }

    public async Task<bool> GetMaxPriceOfProductByCategory(string name)
    {
        var res = await data.Products.Where(x => x.Category.Name == name)
        .MaxAsync(x => x.Price);
        return res > 0;
    }

    public async Task<bool> GetMinPriceOfProductByCategory(string name)
    {
        var res = await data.Products.Where(x => x.Category.Name == name)
        .MinAsync(x => x.Price);
        return res > 0;
    }


    public async Task<Product> GetProductAsync(int id)
    {
        var res = await data.Products.FirstOrDefaultAsync(x => x.Id == id);
        return res??new();
    }

    public async Task<List<Product>> GetProductByCategory(string name)
    {
        return await data.Products.Include(x => x.Category).Where(x=>x.Category!.Name==name).ToListAsync();
    }

    public async Task<List<Product>> GetProducts()
    {
        return await data.Products.ToListAsync();
    }

    public async Task<decimal> GetTotalPriceOfProducts()
    {
        return await data.Products.SumAsync(x => x.Price);
    }


    public async Task<bool> UpdateProductAsync(Product product)
    {
        var upd = await data.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
        if(upd != null)
        {
            upd.Name = product.Name;
            upd.Price = product.Price;
            upd.CategoryId = product.CategoryId;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }
}
