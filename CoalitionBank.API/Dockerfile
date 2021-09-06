FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CoalitionBank.API/CoalitionBank.API.csproj", "CoalitionBank.API/"]
RUN dotnet restore "CoalitionBank.API/CoalitionBank.API.csproj"
COPY . .
WORKDIR "/src/CoalitionBank.API"
RUN dotnet build "CoalitionBank.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoalitionBank.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoalitionBank.API.dll"]
