namespace Athenas.Orders.Application.Services.Interfaces;

public interface IOrderService
{
    Task CreateAsync(CreateOrderDto dto, CancellationToken cancellationToken);
}