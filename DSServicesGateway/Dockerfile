FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 57740
EXPOSE 44358

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY DSServicesGateway/DSServicesGateway.csproj DSServicesGateway/
RUN dotnet restore DSServicesGateway/DSServicesGateway.csproj
COPY . .
WORKDIR /src/DSServicesGateway
RUN dotnet build DSServicesGateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DSServicesGateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DSServicesGateway.dll"]
