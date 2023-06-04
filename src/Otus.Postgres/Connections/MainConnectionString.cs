namespace Otus.Postgres.Connections;

public class MainConnectionString : IMainConnectionString
{
    public MainConnectionString(string connectionString)
    {
        Value = connectionString;
    }
    
    public string Value { get; init; }
}