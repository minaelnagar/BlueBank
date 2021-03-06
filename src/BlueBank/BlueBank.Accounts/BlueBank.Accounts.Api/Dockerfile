#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["BlueBank.Accounts/BlueBank.Accounts.Api/BlueBank.Accounts.Api.csproj", "BlueBank.Accounts/BlueBank.Accounts.Api/"]
COPY ["BlueBank.Accounts/BlueBank.Accounts.Infrastructure/BlueBank.Accounts.Infrastructure.csproj", "BlueBank.Accounts/BlueBank.Accounts.Infrastructure/"]
COPY ["BlueBank.Accounts/BlueBank.Accounts.Core/BlueBank.Accounts.Core.csproj", "BlueBank.Accounts/BlueBank.Accounts.Core/"]
RUN dotnet restore "BlueBank.Accounts/BlueBank.Accounts.Api/BlueBank.Accounts.Api.csproj"
COPY . .
WORKDIR "/src/BlueBank.Accounts/BlueBank.Accounts.Api"
RUN dotnet build "BlueBank.Accounts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlueBank.Accounts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlueBank.Accounts.Api.dll"]
