FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LambdaExploration/LambdaExploration.csproj", "LambdaExploration/"]
RUN dotnet restore "LambdaExploration/LambdaExploration.csproj"
COPY . .
WORKDIR "/src/LambdaExploration"
RUN dotnet build "LambdaExploration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LambdaExploration.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LambdaExploration.dll"]
