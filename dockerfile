# FROM <repo>/<user>/<image>:<tag>
FROM mcr.microsoft.com/dotnet/sdk:latest AS builder

# WORKDIR <dir>
WORKDIR /app
# COPY <src> <dest>
COPY . .
# RUN <cmd>
RUN dotnet publish -c Release -o /app/bin

FROM mcr.microsoft.com/dotnet/sdk:latest AS run
WORKDIR /app/bin
COPY --from=builder /app/bin .
EXPOSE 5001 5000
ENTRYPOINT ["dotnet", "web.api.dll"]
