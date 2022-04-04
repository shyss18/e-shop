FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7209
EXPOSE 5045

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ES.ApiGateway/ES.ApiGateway.csproj", "ES.ApiGateway/"]
RUN dotnet restore "ES.ApiGateway/ES.ApiGateway.csproj"
COPY . .
WORKDIR "/src/ES.ApiGateway"
RUN dotnet build "ES.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ES.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ES.ApiGateway.dll"]
