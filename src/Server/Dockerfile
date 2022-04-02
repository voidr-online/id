FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /voidr/id

COPY ./*.sln ./

COPY ["src/Server/VoidR.ID.Server.csproj", "src/Server/"]
COPY ["src/Infrastructure/VoidR.ID.Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Identity/VoidR.ID.Identity.csproj", "src/Identity/"]

RUN dotnet sln VoidR.ID.sln remove docker-compose.dcproj
RUN dotnet restore

COPY ./src ./src
COPY ./test ./test
RUN dotnet build -c Release --no-restore --nologo

FROM build AS test
ENTRYPOINT ["dotnet", "test", "-c Release", "--no-build", "--nologo"]

FROM build AS publish
RUN dotnet publish -c Release -o /app --no-build --nologo

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "VoidR.ID.Server.dll"]
