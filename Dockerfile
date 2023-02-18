FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5073

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src/

COPY EasyUnitech.NetApi.WebService/EasyUnitech.NetApi.WebService.csproj EasyUnitech.NetApi.WebService/
RUN dotnet restore EasyUnitech.NetApi.WebService/EasyUnitech.NetApi.WebService.csproj
COPY . .
WORKDIR /src/EasyUnitech.NetApi.WebService
RUN dotnet build EasyUnitech.NetApi.WebService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EasyUnitech.NetApi.WebService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app

COPY --from=publish /app .
ENV ASPNETCORE_URLS=http://0.0.0.0:5073/
ENTRYPOINT ["dotnet", "EasyUnitech.NetApi.WebService.dll"]