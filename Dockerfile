FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

#Install dependencies
COPY ./TechTest/TechTest.csproj ./
RUN dotnet restore

#Build application
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TechTest.dll"]
