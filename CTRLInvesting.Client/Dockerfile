FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY ["CTRLInvesting.Client/CTRLInvesting.Client.csproj", "CTRLInvesting.Client/"]
COPY ["CTRLInvesting.Model/CTRLInvesting.Model.csproj", "CTRLInvesting.Model/"]

RUN dotnet restore "CTRLInvesting.Client/CTRLInvesting.Client.csproj" 

COPY . .
WORKDIR "/app/CTRLInvesting.Client"
RUN dotnet build "CTRLInvesting.Client.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "CTRLInvesting.Client.csproj" -c Release -o /app/publish
 

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app 
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CTRLInvesting.Client.dll"]