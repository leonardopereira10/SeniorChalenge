#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SeniorChallenge/SeniorChallenge.csproj", "SeniorChallenge/"]
RUN dotnet restore "SeniorChallenge/SeniorChallenge.csproj"
COPY . .
WORKDIR "/src/SeniorChallenge"
RUN dotnet build "SeniorChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeniorChallenge.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM ubuntu
ARG KEY
ENV KEY="AKR49DI5GKVIERUIS1DPZARMBORTIAEL"
RUN echo $KEY

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeniorChallenge.dll"]