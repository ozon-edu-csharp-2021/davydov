FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY . /app

WORKDIR /app/src/MerchandiseService.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://*:5000

COPY --from=build /app/src/MerchandiseService.Api/out .

ENTRYPOINT ["dotnet", "MerchandiseService.Api.dll"]
