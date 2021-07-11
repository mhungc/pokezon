#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Customer.Api/Customer.Api/Customer.Api.csproj", "Customer.Api/Customer.Api/"]
COPY ["Customer.Api/Customer.Data/Customer.Data.csproj", "Customer.Api/Customer.Data/"]
COPY ["Customer.Api/Customer.Domain/Customer.Domain.csproj", "Customer.Api/Customer.Domain/"]
COPY ["Customer.Api/Customer.Services/Customer.Services.csproj", "Customer.Api/Customer.Services/"]
RUN dotnet restore "Customer.Api/Customer.Api/Customer.Api.csproj"
COPY . .
WORKDIR "/src/Customer.Api/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.Api.dll"]
