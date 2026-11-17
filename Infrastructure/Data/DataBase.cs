using System.Data;
using System.Net.Security;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Npgsql;

namespace Infrastructure.Data;

public class DataBase(DbContextOptions<DataBase>options):DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
