FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CoalitionBank.Services.Accounts/CoalitionBank.Services.Accounts.csproj", "CoalitionBank.Services.Accounts/"]
RUN dotnet restore "CoalitionBank.Services.Accounts/CoalitionBank.Services.Accounts.csproj"
COPY . .
WORKDIR "/src/CoalitionBank.Services.Accounts"
RUN dotnet build "CoalitionBank.Services.Accounts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoalitionBank.Services.Accounts.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoalitionBank.Services.Accounts.dll"]
