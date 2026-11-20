using System.Xml.Serialization;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Repository;

public class CategoryRepository(DataBase dataBase) : ICategoryRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddCategory(Category category)
    {
        data.Categories.Add(category);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var del = await data.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if(del != null)
        {
            data.Categories.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<int> GetAmountOfCategories()
    {
        return await data.Categories.CountAsync();
    }


    public async Task<List<Category>> GetCategories()
    {
        return await data.Categories.ToListAsync();
    }

    public async Task<Category> GetCategory(int id)
    {
        var res = await data.Categories.FirstOrDefaultAsync(x => x.Id == id);
        return res??new();
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        var upd = await data.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
        if(upd != null)
        {
            upd.Name = category.Name;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

}
