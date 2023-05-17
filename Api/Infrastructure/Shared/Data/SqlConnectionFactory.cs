using Api.Shared.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api.Infrastructure.Shared.Data;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;
    private IDbConnection _connection;

    public SqlConnectionFactory(string connectionString) 
        => _connectionString = connectionString;

    public IDbConnection GetOpenConnection()
    {
        if (_connection is { State: ConnectionState.Open })
            return _connection;

        _connection = new SqlConnection(_connectionString);
        _connection.Open();

        return _connection;
    }

    public IDbConnection CreateNewConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }

    public string GetConnectionString() => _connectionString;

    public void Dispose()
    {
        if (_connection is { State: ConnectionState.Open })
        {
            _connection.Dispose();
        }
    }
}
