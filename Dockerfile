FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base

COPY . .
WORKDIR /src
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000;



FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["mailSender-api.csproj", "./"]

RUN dotnet restore "mailSender-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "mailSender-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mailSender-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mailSender-api.dll"]