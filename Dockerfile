# Stage 1: Build Angular App
FROM node:18 AS angular-build
WORKDIR /app

# Copy Angular app source code and install dependencies
COPY smartdatasecurityapp.client/ ./smartdatasecurityapp.client
WORKDIR /app/smartdatasecurityapp.client
RUN npm install --force
RUN npm run build --prod


# Stage 2: Build .NET Core Web API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore dependencies
COPY . .
RUN dotnet restore "SmartdataSecurityApp.Server/SmartdataSecurityApp.Server.csproj"

# Publish the Web API
RUN dotnet publish "SmartdataSecurityApp.Server/SmartdataSecurityApp.Server.csproj" -c Release -o /app/publish
