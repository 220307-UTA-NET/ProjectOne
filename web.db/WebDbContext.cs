namespace web.db;
public interface IDbContext
{
    string ConnectionString();
}
public class WebDbContext : IDbContext
{
    public string MyConnectionString { get; init; } = "Hello C#";
    // public WebDbContext(string connectionString)
    // {
    //     _ConnectionString = connectionString;
    // }
    public string ConnectionString()
    {
        return MyConnectionString;
    }
    
}

