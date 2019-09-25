FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR .
COPY *.sln ./
COPY ./TesteApi.Api.csproj .
RUN echo $(ls)
RUN dotnet restore TesteApi.Api.csproj

COPY . .
WORKDIR .
RUN dotnet build TesteApi.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TesteApi.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TesteApi.Api.dll"]