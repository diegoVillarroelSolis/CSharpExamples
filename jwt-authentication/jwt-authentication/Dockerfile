FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY jwt-authentication/jwt-authentication.csproj jwt-authentication/
RUN dotnet restore jwt-authentication/jwt-authentication.csproj
COPY . .
WORKDIR /src/jwt-authentication
RUN dotnet build jwt-authentication.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish jwt-authentication.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "jwt-authentication.dll"]
