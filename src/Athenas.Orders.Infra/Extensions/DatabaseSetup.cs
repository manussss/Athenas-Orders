namespace Athenas.Orders.Infra.Extensions;

public static class DatabaseSetup
{
    public static void AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrdersContext>(options => options.UseNpgsql(configuration.GetConnectionString("OrdersConnection")));
    }
}