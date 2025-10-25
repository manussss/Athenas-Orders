namespace Athenas.Orders.Application.Services.Interfaces;

public interface IContractService
{
    Task<Contract> CreateAsync(CreateContractDto dto, CancellationToken cancellationToken);
}