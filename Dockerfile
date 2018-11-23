FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TencentCloudMPSample/TencentCloudMPSample.csproj", "TencentCloudMPSample/"]
COPY ["TencentCloudMPSample.EFCore/TencentCloudMPSample.EFCore.csproj", "TencentCloudMPSample.EFCore/"]
RUN dotnet restore "TencentCloudMPSample/TencentCloudMPSample.csproj"
COPY . .
WORKDIR "/src/TencentCloudMPSample"
RUN dotnet build "TencentCloudMPSample.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TencentCloudMPSample.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TencentCloudMPSample.dll"]