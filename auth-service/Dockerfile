FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5105
EXPOSE 7231

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ES.AuthService.Web/ES.AuthService.Web.csproj", "ES.AuthService.Web/"]
COPY ["src/ES.AuthService.Application/ES.AuthService.Application.csproj", "ES.AuthService.Application/"]
COPY ["src/ES.AuthService.Domain/ES.AuthService.Domain.csproj", "ES.AuthService.Domain/"]
COPY ["src/ES.AuthService.Infrastructure/ES.AuthService.Infrastructure.csproj", "ES.AuthService.Infrastructure/"]
RUN dotnet restore "ES.AuthService.Web/ES.AuthService.Web.csproj"

COPY ["/src", "."]
WORKDIR "/src/ES.AuthService.Web"
RUN dotnet build "ES.AuthService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ES.AuthService.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ES.AuthService.Web.dll"]
