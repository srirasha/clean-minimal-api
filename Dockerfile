FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Web.Clean.Minimal.API/Web.Clean.Minimal.API.csproj", "src/Web.Clean.Minimal.API/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "src/Web.Clean.Minimal.API/Web.Clean.Minimal.API.csproj"
COPY . .
WORKDIR "/src/src/Web.Clean.Minimal.API"
RUN dotnet build "Web.Clean.Minimal.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Clean.Minimal.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Clean.Minimal.API.dll"]