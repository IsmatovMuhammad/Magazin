using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repository;

public class ProductRepository(DataBase dataBase) : IProductsRepository
{
    private DataBase data1 = dataBase;
    public async Task<bool> AddProductAsync(Product product)
    {
        using var conn = data1.Connection();
        conn.Open();
        var query = "insert into products(name, price, categoryid)values(@name, @price, @categoryid)";
        var res = await conn.ExecuteAsync(query, product);
        return res > 0;
    }


    public async Task<bool> DeleteProductAsync(int id)
    {
        using var conn = data1.Connection();
        conn.Open();
        var query = "delete from products where id = @id";
        var res = await conn.ExecuteAsync(query, new{id});
        return res > 0;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        using var conn = data1.Connection();
        conn.Open();
        var query = "Select * from products where id = @id";
        var res = await conn.QuerySingleOrDefaultAsync<Product>(query, new{id});
        return res!;
    }

    public async Task<List<Product>> GetProductByCategory(string name)
    {
        using var conn = data1.Connection();
        conn.Open();
        var query = "Select p.* from products p join categories c on c.id = p.categoryid where c.name = @name";
        var res = await conn.QueryAsync<Product>(query, new{name});
        return res.ToList();
    }

    public async Task<List<Product>> GetProducts()
    {
        using var conn = data1.Connection();
        conn.Open();
        var query = "select * from products";
        var res = await conn.QueryAsync<Product>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        using var conn = data1.Connection();
        conn.Open();
        var query = "update products set name = @name, price = @price where id = @id";
        var res = await conn.ExecuteAsync(query, product);
        return res>0;
    }

}
