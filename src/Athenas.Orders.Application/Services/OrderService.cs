namespace Athenas.Orders.Application.Services;

public sealed class OrderService(IOrdersRepository repository) : IOrderService
{
    public async Task CreateAsync(CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var order = (Order)dto;

        order.CalculateTotalValue();

        await repository.CreateAsync(order, cancellationToken);
    }
}