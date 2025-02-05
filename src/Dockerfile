FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY . .

# Restaurar y publicar (esto generará clidriver en la carpeta de salida)
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Fase final
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

RUN apt-get update && apt-get install -y libxml2 && rm -rf /var/lib/apt/lists/*

# Variables de entorno para IBM Db2
ENV IBM_DB_HOME=/app/clidriver
ENV DB2_CLI_DRIVER_INSTALL_PATH=/app/clidriver
ENV LD_LIBRARY_PATH=/app/clidriver/lib:/app/clidriver/lib/icc
ENV PATH=$PATH:/app/clidriver/bin

COPY --from=build /app .

ENTRYPOINT ["dotnet", "DotNetIBMDb2LinuxExample.Console.dll"]