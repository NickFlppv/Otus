FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
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
