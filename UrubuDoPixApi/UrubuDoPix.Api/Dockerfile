FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UrubuDoPixApi/UrubuDoPix.Api/UrubuDoPix.Api.csproj", "UrubuDoPixApi/UrubuDoPix.Api/"]
RUN dotnet restore "UrubuDoPixApi/UrubuDoPix.Api/UrubuDoPix.Api.csproj"
COPY . .
WORKDIR "/src/UrubuDoPixApi/UrubuDoPix.Api"
RUN dotnet build "UrubuDoPix.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UrubuDoPix.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrubuDoPix.Api.dll"]
