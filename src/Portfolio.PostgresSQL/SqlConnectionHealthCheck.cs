using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Portfolio.PostgresSQL;

public class SqlConnectionHealthCheck(IConfiguration configuration, ILogger<SqlConnectionHealthCheck> logger)
{
    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        var connectionString = configuration.GetConnectionString("PostgresSQL") ?? throw new NullReferenceException("a connection string must be defined");
        logger.LogInformation("attempting to create connection");
        using var connection = new NpgsqlConnection(connectionString);
        logger.LogInformation("connection established");
        logger.LogInformation("attempting to open operation with database");
        await connection.OpenAsync(cancellationToken);
        logger.LogInformation("open operation with database: OK");
        await connection.CloseAsync();
        logger.LogInformation("connection with database is now closed: OK");
    }
}