FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StringExample/StringExample.csproj", "StringExample/"]
RUN dotnet restore "StringExample/StringExample.csproj"
COPY . .
WORKDIR "/src/StringExample"
RUN dotnet build "StringExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StringExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StringExample.dll"]
