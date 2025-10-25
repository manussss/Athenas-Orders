namespace Athenas.Orders.Application.Dtos;

public record CreateOrderDto
{
    public IEnumerable<CreateOrderItemDto> OrderItems { get; set; } = [];
    public Guid ContractId { get; set; }

    public static implicit operator Order(CreateOrderDto dto)
    {
        return new Order((IEnumerable<OrderItem>)dto.OrderItems, dto.ContractId);
    }
}