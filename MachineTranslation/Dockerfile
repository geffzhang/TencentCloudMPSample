FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["./MachineTranslation.csproj", "./"]
RUN dotnet restore "./MachineTranslation.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "MachineTranslation.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MachineTranslation.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MachineTranslation.dll"]