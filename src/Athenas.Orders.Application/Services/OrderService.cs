namespace Athenas.Orders.Application.Services;

public sealed class OrderService(IOrdersRepository repository) : IOrderService
{
    public async Task CreateAsync(CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var order = (Order)dto;

        foreach (var orderItem in order.OrderItems)
            orderItem.SetOrderId(order.Id);

        order.CalculateTotalValue();

        await repository.CreateAsync(order, cancellationToken);
    }
    
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }
}