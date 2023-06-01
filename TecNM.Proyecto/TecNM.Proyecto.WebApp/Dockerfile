FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TecNM.Proyecto.WebApp/TecNM.Proyecto.WebApp.csproj", "TecNM.Proyecto.WebApp/"]
RUN dotnet restore "TecNM.Proyecto.WebApp/TecNM.Proyecto.WebApp.csproj"
COPY . .
WORKDIR "/src/TecNM.Proyecto.WebApp"
RUN dotnet build "TecNM.Proyecto.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TecNM.Proyecto.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TecNM.Proyecto.WebApp.dll"]
