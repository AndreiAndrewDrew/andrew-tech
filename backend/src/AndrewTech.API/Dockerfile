FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AndrewTech.API/AndrewTech.API.csproj", "src/AndrewTech.API/"]
COPY ["src/AndrewTech.Application/AndrewTech.Application.csproj", "src/AndrewTech.Application/"]
COPY ["src/AndrewTech.Domain/AndrewTech.Domain.csproj", "src/AndrewTech.Domain/"]
COPY ["src/AndrewTech.Infrastructure/AndrewTech.Infrastructure.csproj", "src/AndrewTech.Infrastructure/"]
RUN dotnet restore "src/AndrewTech.API/AndrewTech.API.csproj"
COPY . .
WORKDIR "/src/src/AndrewTech.API"
RUN dotnet build "./AndrewTech.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AndrewTech.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AndrewTech.API.dll"]
