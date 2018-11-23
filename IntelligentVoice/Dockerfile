FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["./IntelligentVoice.csproj", "./"]
RUN dotnet restore "./IntelligentVoice.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "IntelligentVoice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IntelligentVoice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IntelligentVoice.dll"]