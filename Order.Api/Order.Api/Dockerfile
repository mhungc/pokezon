#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Order.Api/Order.Api/Order.Api.csproj", "Order.Api/Order.Api/"]
COPY ["Order.Api/Order.Services/Order.Services.csproj", "Order.Api/Order.Services/"]
COPY ["Order.Api/Order.Domain/Order.Domain.csproj", "Order.Api/Order.Domain/"]
COPY ["Order.Api/Order.Data/Order.Data.csproj", "Order.Api/Order.Data/"]
COPY ["Customer.Api/Customer.Domain/Customer.Domain.csproj", "Customer.Api/Customer.Domain/"]
RUN dotnet restore "Order.Api/Order.Api/Order.Api.csproj"
COPY . .
WORKDIR "/src/Order.Api/Order.Api"
RUN dotnet build "Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.Api.dll"]
