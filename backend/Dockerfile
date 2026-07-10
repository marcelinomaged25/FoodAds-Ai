FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY NuGet.Config ./
COPY FoodAdsAI.sln ./
COPY src/FoodAdsAI.Api/FoodAdsAI.Api.csproj src/FoodAdsAI.Api/
COPY src/FoodAdsAI.Application/FoodAdsAI.Application.csproj src/FoodAdsAI.Application/
COPY src/FoodAdsAI.Domain/FoodAdsAI.Domain.csproj src/FoodAdsAI.Domain/
COPY src/FoodAdsAI.Infrastructure/FoodAdsAI.Infrastructure.csproj src/FoodAdsAI.Infrastructure/

RUN dotnet restore FoodAdsAI.sln

COPY . .
RUN dotnet publish src/FoodAdsAI.Api/FoodAdsAI.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FoodAdsAI.Api.dll"]
