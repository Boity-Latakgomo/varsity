FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/varsity.Web.Host/varsity.Web.Host.csproj", "src/varsity.Web.Host/"]
COPY ["src/varsity.Web.Core/varsity.Web.Core.csproj", "src/varsity.Web.Core/"]
COPY ["src/varsity.Application/varsity.Application.csproj", "src/varsity.Application/"]
COPY ["src/varsity.Core/varsity.Core.csproj", "src/varsity.Core/"]
COPY ["src/varsity.EntityFrameworkCore/varsity.EntityFrameworkCore.csproj", "src/varsity.EntityFrameworkCore/"]
WORKDIR "/src/src/varsity.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/varsity.Web.Host", "src/varsity.Web.Host"]
COPY ["src/varsity.Web.Core", "src/varsity.Web.Core"]
COPY ["src/varsity.Application", "src/varsity.Application"]
COPY ["src/varsity.Core", "src/varsity.Core"]
COPY ["src/varsity.EntityFrameworkCore", "src/varsity.EntityFrameworkCore"]
WORKDIR "/src/src/varsity.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "varsity.Web.Host.dll"]
