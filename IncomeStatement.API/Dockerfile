#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IncomeStatement.API/IncomeStatement.API.csproj", "IncomeStatement.API/"]
COPY ["IncomeStatement.Application/IncomeStatement.Application.csproj", "IncomeStatement.Application/"]
COPY ["IncomeStatement.Domain/IncomeStatement.Domain.csproj", "IncomeStatement.Domain/"]
COPY ["IncomeStatement.Infrastructure/IncomeStatement.Infrastructure.csproj", "IncomeStatement.Infrastructure/"]
RUN dotnet restore "IncomeStatement.API/IncomeStatement.API.csproj"
COPY . .
WORKDIR "/src/IncomeStatement.API"
RUN dotnet build "IncomeStatement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IncomeStatement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncomeStatement.API.dll"]