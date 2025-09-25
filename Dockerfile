# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app

# Copy project files (prieš tai būk task3 kataloge, tad KodasApp yra po ./KodasApp)
COPY ./KodasApp/ ./KodasApp/
WORKDIR /app/KodasApp

# Publish the app
RUN dotnet publish -c Release -o out

# Runtime stage - Use ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview
WORKDIR /app
COPY --from=build /app/KodasApp/out ./

# Run the app
ENTRYPOINT ["dotnet", "KodasApp.dll"]
