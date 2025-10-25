namespace Athenas.Orders.Domain.Entities;

public sealed class OrderItem : Entity
{
    public Guid OrderId { get; private set; }
    public decimal Value { get; private set; }
    public int Quantity { get; private set; }
}