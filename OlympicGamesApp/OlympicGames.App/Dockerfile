# Builds a Docker image

#Required to run Application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /App
COPY ./ ./
RUN dotnet publish -c Release

#Pare down enviornment
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run
WORKDIR /App

#COPY --from=build /App/OlympicGames.App/bin/Debug/net6.0/ ./
COPY --from=build /App/OlympicGames.App/bin/Release/net6.0/publish/ ./
ENTRYPOINT ["dotnet","./OlympicGames.App.dll"]
#ENTRYPOINT ["dotnet","./OlympicGames.App/bin/Debug/net6.0/OlympicGames.App.dll"]