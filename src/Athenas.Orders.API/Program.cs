var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseInjection(builder.Configuration);
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

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
.WithName("CreateContract")
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

app.MapGet("/api.v1/orders", async ([FromServices] IOrderService service) =>
{
    var orders = await service.GetAllAsync();

    return Results.Ok(orders);
})
.WithName("GetOrders")
.WithOpenApi();;

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrdersContext>();
    await db.Database.MigrateAsync();
}

await app.RunAsync();