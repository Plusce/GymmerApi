FROM ubuntu:22.04

FROM mcr.microsoft.com/dotnet/sdk:7.0.102-jammy-amd64

# Generate Certificates
# RUN dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p TestPassword
RUN dotnet dev-certs https --trust

WORKDIR /gymmer-api