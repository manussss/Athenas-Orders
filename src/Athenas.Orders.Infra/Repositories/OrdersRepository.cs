namespace Athenas.Orders.Infra.Repositories;

public class OrdersRepository(OrdersContext context) : IOrdersRepository
{
    public async Task<Contract> CreateAsync(Contract contract, CancellationToken cancellationToken)
    {
        await context.AddAsync(contract, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return contract;
    }

    public async Task CreateAsync(Order order, CancellationToken cancellationToken)
    {
        await context.AddAsync(order, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}