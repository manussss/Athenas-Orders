namespace Athenas.Orders.Application.Dtos;

public record CreateOrderItemDto(decimal Value, int Quantity)
{
    public static implicit operator OrderItem(CreateOrderItemDto dto)
    {
        return new OrderItem(dto.Value, dto.Quantity);
    }
}