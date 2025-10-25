var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseInjection(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/v1/contract", async (
    [FromServices] IContractService service,
    [FromBody] CreateContractDto dto,
    CancellationToken cancellationToken
    ) =>
{
    var contract = await service.CreateAsync(dto, cancellationToken);

    return Results.Created("api/v1/contract", new { Id = contract.Id, Number = contract.Number });
})
.WithName("CreateOrder")
.WithOpenApi();

app.MapPost("/api/v1/orders", async (
    [FromServices] IOrderService service,
    [FromBody] CreateOrderDto dto,
    CancellationToken cancellationToken
    ) =>
{
    await service.CreateAsync(dto, cancellationToken);

    return Results.Created();
})
.WithName("CreateOrder")
.WithOpenApi();

await app.RunAsync();