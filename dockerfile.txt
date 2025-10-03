# Use official .NET SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only project file first for caching
COPY BigSun_Api/BigSun_Api.csproj BigSun_Api/
RUN dotnet restore BigSun_Api/BigSun_Api.csproj

# Copy rest of the code
COPY . .

# Build and publish
WORKDIR /src/BigSun_Api
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BigSun_Api.dll"]
