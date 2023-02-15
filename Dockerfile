# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY src/. .
COPY src/*.csproj ./shopStore/
RUN dotnet restore

# copy everything else and build app
COPY src/. ./shopStore/
WORKDIR /source/shopStore
RUN dotnet publish -c release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "shopStore.dll"]