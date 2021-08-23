FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ABTestTaskAPI.csproj", ""]
RUN dotnet restore "./ABTestTaskAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ABTestTaskAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ABTestTaskAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# if $PORT provided run on it
ENV ASPNETCORE_URLS http://*:$PORT
ENTRYPOINT ["dotnet", "ABTestTaskAPI.dll"]