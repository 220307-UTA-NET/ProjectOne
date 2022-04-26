#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Project1.Api/Project1.Api.csproj", "Project1.Api/"]
RUN dotnet restore "Project1.Api/Project1.Api.csproj"
COPY . .
WORKDIR "/src/Project1.Api"
RUN dotnet build "Project1.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project1.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project1.Api.dll"]