FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TestExample/TestExample.csproj", "TestExample/"]
RUN dotnet restore "TestExample/TestExample.csproj"
COPY . .
WORKDIR "/src/TestExample"
RUN dotnet build "TestExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestExample.dll"]
