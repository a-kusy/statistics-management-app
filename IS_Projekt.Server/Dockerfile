FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV DB_CONNECTION_STRING="server=db;user=root;database=accidentstatistics;password=;port=3306"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IS_Projekt.Server/IS_Projekt.Server.csproj", "IS_Projekt.Server/"]
COPY ["IS_Projekt.Core/IS_Projekt.Core.csproj", "IS_Projekt.Core/"]
RUN dotnet restore "IS_Projekt.Server/IS_Projekt.Server.csproj"
COPY . .
WORKDIR "/src/IS_Projekt.Server"
RUN dotnet build "IS_Projekt.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IS_Projekt.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IS_Projekt.Server.dll"]