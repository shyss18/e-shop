FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5102
EXPOSE 7048

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ES.ChatService.Api/ES.ChatService.Api.csproj", "ES.ChatService.Api/"]
COPY ["src/ES.ChatService.Domain/ES.ChatService.Domain.csproj", "ES.ChatService.Domain/"]
RUN dotnet restore "ES.ChatService.Api/ES.ChatService.Api.csproj"

COPY ["/src", "."]
WORKDIR "/src/ES.ChatService.Api"
RUN dotnet build "ES.ChatService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ES.ChatService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ES.ChatService.Api.dll"]
