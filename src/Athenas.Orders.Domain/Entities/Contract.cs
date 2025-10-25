namespace Athenas.Orders.Domain.Entities;

public sealed class Contract : Entity
{
    public Guid Number { get; private set; } = Guid.NewGuid();
    public EProduct Product { get; private set; }

    public Contract(EProduct product)
    {
        Product = product;
    }

    protected Contract()
    {
        
    }
}