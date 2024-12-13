using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    readonly string connectionString="host=localhost;port=5432; database=TestDB; user id=postgres; password=1234";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
    
}