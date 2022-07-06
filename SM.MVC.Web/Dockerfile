#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SM.MVC.Web/SM.MVC.Web.csproj", "SM.MVC.Web/"]
COPY ["EmailService/EmailService.csproj", "EmailService/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["IoC/IoC.csproj", "IoC/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "SM.MVC.Web/SM.MVC.Web.csproj"
COPY . .
WORKDIR "/src/SM.MVC.Web"
RUN dotnet build "SM.MVC.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SM.MVC.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SM.MVC.Web.dll"]
