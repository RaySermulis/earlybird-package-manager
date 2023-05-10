#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EarlyBird.Packages.Api/EarlyBird.Packages.Api.csproj", "EarlyBird.Packages.Api/"]
RUN dotnet restore "EarlyBird.Packages.Api/EarlyBird.Packages.Api.csproj"
COPY . .
WORKDIR "/src/EarlyBird.Packages.Api"
RUN dotnet build "EarlyBird.Packages.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EarlyBird.Packages.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EarlyBird.Packages.Api.dll"]