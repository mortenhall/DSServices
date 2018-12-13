FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY NumberGamesProvider/NumberGamesProvider.csproj NumberGamesProvider/
RUN dotnet restore NumberGamesProvider/NumberGamesProvider.csproj
COPY . .
WORKDIR /src/NumberGamesProvider
RUN dotnet build NumberGamesProvider.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NumberGamesProvider.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NumberGamesProvider.dll"]
