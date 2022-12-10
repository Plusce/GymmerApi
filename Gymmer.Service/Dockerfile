FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Polls.Application/Polls.Application.csproj", "Polls.Application/"]
RUN dotnet restore "Polls.Application/Polls.Application.csproj"
COPY . .
WORKDIR "/src/Polls.Application"
RUN dotnet build "Polls.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Polls.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polls.Application.dll"]
