FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /source

COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app --no-restore -c Release

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
EXPOSE 5000

COPY --from=build /app/published-app /app
ENTRYPOINT ["dotnet", "Otus.Service.dll"]
