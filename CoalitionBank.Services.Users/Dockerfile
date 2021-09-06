FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CoalitionBank.Services.Users/CoalitionBank.Services.Users.csproj", "CoalitionBank.Services.Users/"]
RUN dotnet restore "CoalitionBank.Services.Users/CoalitionBank.Services.Users.csproj"
COPY . .
WORKDIR "/src/CoalitionBank.Services.Users"
RUN dotnet build "CoalitionBank.Services.Users.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoalitionBank.Services.Users.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoalitionBank.Services.Users.dll"]
