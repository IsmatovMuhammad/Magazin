using System.Xml.Serialization;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repository;

public class CategoryRepository(DataBase data) : ICategoryRepository
{
    private DataBase dataBase = data;
    public async Task<bool> AddCategory(Category category)
    {
        using var conn = dataBase.Connection();
        conn.Open();
        var query = "insert into categories(name)values(@name)";
        var res = await conn.ExecuteAsync(query, category);
        return res > 0;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        using var conn = dataBase.Connection();
        conn.Open();
        var query = "delete from categories where id = @id";
        var res = await conn.ExecuteAsync(query, new{id});
        return res > 0;
    }

    public async Task<List<Category>> GetCategories()
    {
        using var conn = dataBase.Connection();
        conn.Open();
        var query = "select * from categories";
        var res = await conn.QueryAsync<Category>(query);
        return res.ToList();
    }

    public async Task<Category> GetCategory(int id)
    {
        using var conn = dataBase.Connection();
        conn.Open();
        var query = "Select * from categories where id = @id";
        var res = await conn.QuerySingleOrDefaultAsync<Category>(query, new{id});
        return res!;
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        using var conn = dataBase.Connection();
        conn.Open();
        var query = "update categories set name = @name where id = @id";
        var res = await conn.ExecuteAsync(query, category);
        return res > 0;
    }

}
