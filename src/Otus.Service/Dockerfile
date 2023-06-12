FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["Otus.Contracts/Otus.Contracts.csproj", "Otus.Contracts/"]
COPY ["Otus.Core/Otus.Core.csproj", "Otus.Core/"]
COPY ["Otus.Domain/Otus.Domain.csproj", "Otus.Domain/"]
COPY ["Otus.DataAccess/Otus.DataAccess.csproj", "Otus.DataAccess/"]
COPY ["Otus.Postgres/Otus.Postgres.csproj", "Otus.Postgres/"]
COPY ["Otus.Service/Otus.Service.csproj", "Otus.Service/"]

RUN dotnet restore "Otus.Service/Otus.Service.csproj"
COPY . .
WORKDIR "/src/Otus.Service"
RUN dotnet build "Otus.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Otus.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Otus.Service.dll"]
