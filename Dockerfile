# Base image for ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Stage 1: Build the Angular app (with Node.js and Angular CLI)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS with-node
RUN apt-get update \
    && apt-get install -y curl \
    && curl -sL https://deb.nodesource.com/setup_20.x | bash \
    && apt-get install -y nodejs \
    && npm install -g @angular/cli

# Stage 2: Build Angular and ASP.NET Core projects
FROM with-node AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["SmartdataSecurityApp.Server/SmartdataSecurityApp.Server.csproj", "SmartdataSecurityApp.Server/"]
COPY ["smartdatasecurityapp.client/smartdatasecurityapp.esproj", "smartdatasecurityapp.client/"]

# Restore dependencies
RUN dotnet restore "SmartdataSecurityApp.Server/SmartdataSecurityApp.Server.csproj"

# Copy the rest of the source code
COPY . .

# Build the Angular app
WORKDIR /src/smartdatasecurityapp.client
RUN npm ci --force  # Install dependencies
RUN npm run build --prod  # This generates the Angular build output in /src/smartdatasecurityapp/dist

# Build the ASP.NET Core app
WORKDIR /src/SmartdataSecurityApp.Server
RUN dotnet build "SmartdataSecurityApp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish the ASP.NET Core app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SmartdataSecurityApp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final stage, copy everything to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/smartdatasecurityapp.client/dist/smartdatasecurityapp.client/browser /app/wwwroot  

# Set the entry point for the container
ENTRYPOINT ["dotnet", "SmartdataSecurityApp.Server.dll"]
