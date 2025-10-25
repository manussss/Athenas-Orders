FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Athenas.Orders.API/Athenas.Orders.API.csproj", "Athenas.Orders.API/"]
COPY ["Athenas.Orders.Application/Athenas.Orders.Application.csproj", "Athenas.Orders.Application/"]
COPY ["Athenas.Orders.Domain/Athenas.Orders.Domain.csproj", "Athenas.Orders.Domain/"]
COPY ["Athenas.Orders.Infra/Athenas.Orders.Infra.csproj", "Athenas.Orders.Infra/"]

RUN dotnet restore "Athenas.Orders.API/Athenas.Orders.API.csproj"

COPY . .

WORKDIR "/src/Athenas.Orders.API"
RUN dotnet build "Athenas.Orders.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Athenas.Orders.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Athenas.Orders.API.dll"]