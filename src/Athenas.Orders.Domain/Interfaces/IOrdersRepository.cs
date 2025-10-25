namespace Athenas.Orders.Domain.Interfaces;

public interface IOrdersRepository
{
    Task CreateAsync(Order order, CancellationToken cancellationToken);
    Task<Contract> CreateAsync(Contract order, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetAllAsync();
}