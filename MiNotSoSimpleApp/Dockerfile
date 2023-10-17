FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MiNotSoSimpleApp.csproj", "."]
RUN dotnet restore "./MiNotSoSimpleApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MiNotSoSimpleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiNotSoSimpleApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiNotSoSimpleApp.dll"]