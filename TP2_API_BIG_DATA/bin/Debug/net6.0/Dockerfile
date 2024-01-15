# Utiliser une image ASP.NET Core SDK pour construire l'application
FROM  mcr.microsoft.com/dotnet/nightly/sdk:6.0-alpine AS build

WORKDIR /app

COPY . .

RUN dotnet publish -c Release -o out

EXPOSE 70

CMD ["dotnet", "out/TP2_API_BIG_DATA.dll"]