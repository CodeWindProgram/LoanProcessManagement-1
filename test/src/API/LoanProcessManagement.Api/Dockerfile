#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/API/LoanProcessManagement.Api/LoanProcessManagement.Api.csproj", "src/API/LoanProcessManagement.Api/"]
COPY ["src/Infrastructure/LoanProcessManagement.Infrastructure/LoanProcessManagement.Infrastructure.csproj", "src/Infrastructure/LoanProcessManagement.Infrastructure/"]
COPY ["src/Core/LoanProcessManagement.Application/LoanProcessManagement.Application.csproj", "src/Core/LoanProcessManagement.Application/"]
COPY ["src/Core/LoanProcessManagement.Domain/LoanProcessManagement.Domain.csproj", "src/Core/LoanProcessManagement.Domain/"]
COPY ["src/Infrastructure/LoanProcessManagement.Identity/LoanProcessManagement.Identity.csproj", "src/Infrastructure/LoanProcessManagement.Identity/"]
COPY ["src/Infrastructure/LoanProcessManagement.Persistence/LoanProcessManagement.Persistence.csproj", "src/Infrastructure/LoanProcessManagement.Persistence/"]
RUN dotnet restore "src/API/LoanProcessManagement.Api/LoanProcessManagement.Api.csproj"
COPY . .
WORKDIR "/src/src/API/LoanProcessManagement.Api"
RUN dotnet build "LoanProcessManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoanProcessManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoanProcessManagement.Api.dll"]
