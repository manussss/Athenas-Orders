namespace Athenas.Orders.Application.Dtos;

public record CreateContractDto
{
    public EProduct Product { get; set; }

    public CreateContractDto(EProduct product)
    {
        Product = product;
    }

    public static implicit operator Contract(CreateContractDto dto)
    {
        return new Contract(dto.Product);
    }
}