FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gymmer.Application/Gymmer.Application.csproj", "Gymmer.Application/"]
RUN dotnet restore "Gymmer.Application/Gymmer.Application.csproj"
COPY . .
WORKDIR "/src/Gymmer.Application"
RUN dotnet build "Gymmer.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gymmer.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polls.Application.dll"]
