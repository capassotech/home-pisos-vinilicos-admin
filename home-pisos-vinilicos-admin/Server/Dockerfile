# Utiliza la imagen oficial de .NET como base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Usa una imagen SDK de .NET para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["home-pisos-vinilicos-admin.Server/home-pisos-vinilicos-admin.Server.csproj", "home-pisos-vinilicos-admin.Server/"]
RUN dotnet restore "home-pisos-vinilicos-admin.Server/home-pisos-vinilicos-admin.Server.csproj"
COPY . .
WORKDIR "/src/home-pisos-vinilicos-admin.Server"
RUN dotnet build "home-pisos-vinilicos-admin.Server.csproj" -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "home-pisos-vinilicos-admin.Server.csproj" -c Release -o /app/publish

# Configura la imagen final para ejecución
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "home-pisos-vinilicos-admin.Server.dll"]
