FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Assignment12_Docker_Gateway.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app
 
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "dotnet", "Assignment12_Docker_Gateway.dll" ]