namespace Athenas.Orders.Infra.Data;

public class OrdersContext(DbContextOptions<OrdersContext> options) : DbContext(options)
{
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Contract> Contract { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(OrdersContext).Assembly);

            base.OnModelCreating(builder);
        }
}