FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CSharpExplore/CSharpExplore.csproj", "CSharpExplore/"]
RUN dotnet restore "CSharpExplore/CSharpExplore.csproj"
COPY . .
WORKDIR "/src/CSharpExplore"
RUN dotnet build "CSharpExplore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpExplore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpExplore.dll"]
