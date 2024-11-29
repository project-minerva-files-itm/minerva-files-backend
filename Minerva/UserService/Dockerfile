# Fase de construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar el archivo .csproj y restaurar las dependencias (separado para mejorar la caché de Docker)
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y construir el proyecto
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Fase de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Copiar los archivos publicados desde la fase de construcción
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "UserService.dll"]
