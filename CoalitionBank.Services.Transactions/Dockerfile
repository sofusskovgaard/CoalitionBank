FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CoalitionBank.Services.Transactions/CoalitionBank.Services.Transactions.csproj", "CoalitionBank.Services.Transactions/"]
RUN dotnet restore "CoalitionBank.Services.Transactions/CoalitionBank.Services.Transactions.csproj"
COPY . .
WORKDIR "/src/CoalitionBank.Services.Transactions"
RUN dotnet build "CoalitionBank.Services.Transactions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoalitionBank.Services.Transactions.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoalitionBank.Services.Transactions.dll"]
