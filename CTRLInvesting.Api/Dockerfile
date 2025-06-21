FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

COPY ["CTRLInvesting.Api/CTRLInvesting.Api.csproj", "CTRLInvesting.Api/"]
COPY ["CTRLInvesting.Model/CTRLInvesting.Model.csproj", "CTRLInvesting.Model/"]

RUN dotnet restore "CTRLInvesting.Api/CTRLInvesting.Api.csproj" 

COPY . .
WORKDIR "/app/CTRLInvesting.Api"
RUN dotnet build "CTRLInvesting.Api.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "CTRLInvesting.Api.csproj" -c Release -o /app/publish
 

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app 
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CTRLInvesting.Api.dll"]