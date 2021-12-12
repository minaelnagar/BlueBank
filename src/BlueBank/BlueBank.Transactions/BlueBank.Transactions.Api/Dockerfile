#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["BlueBank.Transactions/BlueBank.Transactions.Api/BlueBank.Transactions.Api.csproj", "BlueBank.Transactions/BlueBank.Transactions.Api/"]
COPY ["BlueBank.Transactions/BlueBank.Transactions.Infrastructure/BlueBank.Transactions.Infrastructure.csproj", "BlueBank.Transactions/BlueBank.Transactions.Infrastructure/"]
COPY ["BlueBank.Transactions/BlueBank.Transactions.Core/BlueBank.Transactions.Core.csproj", "BlueBank.Transactions/BlueBank.Transactions.Core/"]
RUN dotnet restore "BlueBank.Transactions/BlueBank.Transactions.Api/BlueBank.Transactions.Api.csproj"
COPY . .
WORKDIR "/src/BlueBank.Transactions/BlueBank.Transactions.Api"
RUN dotnet build "BlueBank.Transactions.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlueBank.Transactions.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlueBank.Transactions.Api.dll"]