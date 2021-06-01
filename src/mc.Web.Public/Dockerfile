#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/mc.Web.Public/mc.Web.Public.csproj", "src/mc.Web.Public/"]
COPY ["src/mc.Web.Core/mc.Web.Core.csproj", "src/mc.Web.Core/"]
COPY ["src/mc.Application/mc.Application.csproj", "src/mc.Application/"]
COPY ["src/mc.Application.Shared/mc.Application.Shared.csproj", "src/mc.Application.Shared/"]
COPY ["src/mc.Core.Shared/mc.Core.Shared.csproj", "src/mc.Core.Shared/"]
COPY ["src/mc.Core/mc.Core.csproj", "src/mc.Core/"]
COPY ["src/mc.EntityFrameworkCore/mc.EntityFrameworkCore.csproj", "src/mc.EntityFrameworkCore/"]
COPY ["src/mc.GraphQL/mc.GraphQL.csproj", "src/mc.GraphQL/"]
RUN dotnet restore "src/mc.Web.Public/mc.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/mc.Web.Public"
RUN dotnet build "mc.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mc.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mc.Web.Public.dll"]
