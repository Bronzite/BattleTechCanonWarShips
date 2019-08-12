FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BattleTechCanonWarships/BattleTechCanonWarships.csproj", "BattleTechCanonWarships/"]
RUN dotnet restore "BattleTechCanonWarships/BattleTechCanonWarships.csproj"
COPY . .
WORKDIR "/src/BattleTechCanonWarships"
RUN dotnet build "BattleTechCanonWarships.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BattleTechCanonWarships.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BattleTechCanonWarships.dll"]