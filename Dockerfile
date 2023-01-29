FROM ubuntu:22.04

FROM mcr.microsoft.com/dotnet/sdk:7.0.102-jammy-amd64

COPY . /gymmer-api

WORKDIR /gymmer-api