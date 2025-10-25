namespace Athenas.Orders.Domain.Entities;

public sealed class Order : Entity
{
    public IEnumerable<OrderItem> OrderItems { get; private set; } = [];
    public Contract? Contract { get; private set; } = default;
    public Guid ContractId { get; private set; }
    public decimal TotalValue { get; private set; }

    public Order(
        IEnumerable<OrderItem> orderItems,
        Guid contractId)
    {
        OrderItems = orderItems;
        ContractId = contractId;
    }
}