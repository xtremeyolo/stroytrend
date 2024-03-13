FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/backend
COPY /StroyTrend/*.csproj .
RUN dotnet restore
COPY /StroyTrend .
RUN dotnet publish -c release -o ./publish --no-restore /p:UseAppHost=false

FROM node:16-alpine as build-frontend
WORKDIR /src/frontend
COPY /Frontend/package*.json ./
RUN npm install
COPY /Frontend ./
RUN npm run build

FROM base as final
WORKDIR /app
COPY --from=build /src/backend/publish .
COPY --from=build-frontend /src/frontend/dist ./wwwroot
CMD [ "dotnet", "StroyTrend.dll" ]