FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EqualExploration/EqualExploration.csproj", "EqualExploration/"]
RUN dotnet restore "EqualExploration/EqualExploration.csproj"
COPY . .
WORKDIR "/src/EqualExploration"
RUN dotnet build "EqualExploration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EqualExploration.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EqualExploration.dll"]
