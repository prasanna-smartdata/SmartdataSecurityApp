# Base image with .NET 8 runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Node.js and Angular setup
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS with-node
WORKDIR /src
RUN curl https://nodejs.org/dist/v18.18.0/node-v18.18.0-win-x64.zip --output node.zip
RUN tar -xf node.zip
USER ContainerAdministrator
RUN setx /M path "%path%;C:\src\node-v18.18.0-win-x64"
USER ContainerUser
RUN npm install -g @angular/cli

# Build the .NET and Angular projects
FROM with-node AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmartdataSecurityApp.Server/SmartdataSecurityApp.Server.csproj", "SmartdataSecurityApp.Server/"]
COPY ["smartdatasecurityapp.client/smartdatasecurityapp.client.esproj", "smartdatasecurityapp.client/"]
RUN dotnet restore "./SmartdataSecurityApp.Server/SmartdataSecurityApp.Server.csproj"
COPY . .
WORKDIR "/src/SmartdataSecurityApp.Server"
RUN dotnet build "./SmartdataSecurityApp.Server.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Publish .NET API
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartdataSecurityApp.Server.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Build Angular SPA
FROM with-node AS angular-build
WORKDIR /src/smartdatasecurityapp.client
RUN npm install
RUN npm run build --prod

# Copy Angular build to wwwroot in .NET project
FROM publish AS final
WORKDIR /app
COPY --from=angular-build /src/smartdatasecurityapp.client/dist /app/wwwroot

# Copy published .NET app
COPY --from=publish /app/publish .

# Expose ports
EXPOSE 80

# Set entrypoint for .NET API
ENTRYPOINT ["dotnet", "SmartdataSecurityApp.Server.dll"]
