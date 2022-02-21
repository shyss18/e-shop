FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5106
EXPOSE 7256

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ES.ProductService.Api/ES.ProductService.Api.csproj", "ES.ProductService.Api/"]
COPY ["src/ES.ProductService.Application/ES.ProductService.Application.csproj", "ES.ProductService.Application/"]
COPY ["src/ES.ProductService.Domain/ES.ProductService.Domain.csproj", "ES.ProductService.Domain/"]
COPY ["src/ES.ProductService.Infrastructure/ES.ProductService.Infrastructure.csproj", "ES.ProductService.Infrastructure/"]
COPY ["src/ES.ProductService.Migrations/ES.ProductService.Migrations.csproj", "ES.ProductService.Migrations/"]
RUN dotnet restore "ES.ProductService.Api/ES.ProductService.Api.csproj"

COPY ["/src", "."]
WORKDIR "/src/ES.ProductService.Api"
RUN dotnet build "ES.ProductService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ES.ProductService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ES.ProductService.Api.dll"]
