namespace Athenas.Orders.Application.Services;

public sealed class ContractService(IOrdersRepository ordersRepository) : IContractService
{
    public async Task<Contract> CreateAsync(CreateContractDto dto, CancellationToken cancellationToken)
    {
        var contract = (Contract)dto;

        return await ordersRepository.CreateAsync(contract, cancellationToken);
    }
}