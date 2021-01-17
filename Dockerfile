# Specify base image.
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy everything and restore / publish the solution.
COPY . ./
RUN dotnet build ./FrostAura.Clients.Events/FrostAura.Clients.Events.csproj
RUN dotnet build ./FrostAura.Clients.Events.Core.Tests/FrostAura.Clients.Events.Core.Tests.csproj
RUN dotnet build ./FrostAura.Clients.Events.Data.Tests/FrostAura.Clients.Events.Data.Tests.csproj
RUN dotnet publish ./FrostAura.Clients.Events/FrostAura.Clients.Events.csproj -c Release -o /app/out

# Build runtime image off the correct base.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "FrostAura.Clients.Events.dll"]
EXPOSE 80