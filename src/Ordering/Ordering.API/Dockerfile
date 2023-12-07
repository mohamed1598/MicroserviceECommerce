#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Ordering/Ordering.API/Ordering.API.csproj", "src/Ordering/Ordering.API/"]
COPY ["src/Common/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "src/Common/EventBusRabbitMQ/"]
COPY ["src/Ordering/Ordering.Application/Ordering.Application.csproj", "src/Ordering/Ordering.Application/"]
COPY ["src/Ordering/Ordering.Core/Ordering.Core.csproj", "src/Ordering/Ordering.Core/"]
COPY ["src/Ordering/Ordering.Infrastracture/Ordering.Infrastracture.csproj", "src/Ordering/Ordering.Infrastracture/"]
RUN dotnet restore "./src/Ordering/Ordering.API/./Ordering.API.csproj"
COPY . .
WORKDIR "/src/src/Ordering/Ordering.API"
RUN dotnet build "./Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]