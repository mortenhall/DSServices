FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY SubscriptionServices/SubscriptionServices.csproj SubscriptionServices/
RUN dotnet restore SubscriptionServices/SubscriptionServices.csproj
COPY . .
WORKDIR /src/SubscriptionServices
RUN dotnet build SubscriptionServices.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SubscriptionServices.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SubscriptionServices.dll"]
