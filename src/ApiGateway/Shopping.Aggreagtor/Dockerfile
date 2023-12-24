#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ApiGateway/Shopping.Aggreagtor/Shopping.Aggregator.csproj", "src/ApiGateway/Shopping.Aggreagtor/"]
RUN dotnet restore "./src/ApiGateway/Shopping.Aggreagtor/./Shopping.Aggregator.csproj"
COPY . .
WORKDIR "/src/src/ApiGateway/Shopping.Aggreagtor"
RUN dotnet build "./Shopping.Aggregator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Shopping.Aggregator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.Aggregator.dll"]