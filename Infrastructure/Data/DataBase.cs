using System.Data;
using Microsoft.VisualBasic;
using Npgsql;

namespace Infrastructure.Data;

public class DataBase
{
    private string connectionString = "Host=localhost;Port=5432;DataBase=Magazin;Username=postgres;Password=1234";
    public NpgsqlConnection Connection() => new NpgsqlConnection(connectionString);
}
