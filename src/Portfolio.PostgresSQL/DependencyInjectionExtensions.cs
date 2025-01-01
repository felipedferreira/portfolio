using Portfolio.PostgresSQL;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPostgresSQL(this IServiceCollection services)
        {
            return services.AddScoped<SqlConnectionHealthCheck>();
        }
    }    
}