FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskExample2/TaskExample2.csproj", "TaskExample2/"]
RUN dotnet restore "TaskExample2/TaskExample2.csproj"
COPY . .
WORKDIR "/src/TaskExample2"
RUN dotnet build "TaskExample2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskExample2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskExample2.dll"]
