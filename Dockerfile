FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyService/MyService.csproj", "MyService/"]
RUN dotnet restore "MyService/MyService.csproj"
COPY . .
WORKDIR "/src/MyService"
RUN dotnet build "MyService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyService.dll"]