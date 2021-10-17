#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["test/LoanProcessManagement.API.IntegrationTests/LoanProcessManagement.API.IntegrationTests.csproj", "test/LoanProcessManagement.API.IntegrationTests/"]
COPY ["src/Infrastructure/LoanProcessManagement.Persistence/LoanProcessManagement.Persistence.csproj", "src/Infrastructure/LoanProcessManagement.Persistence/"]
COPY ["src/Core/LoanProcessManagement.Application/LoanProcessManagement.Application.csproj", "src/Core/LoanProcessManagement.Application/"]
COPY ["src/Core/LoanProcessManagement.Domain/LoanProcessManagement.Domain.csproj", "src/Core/LoanProcessManagement.Domain/"]
COPY ["src/API/LoanProcessManagement.Api/LoanProcessManagement.Api.csproj", "src/API/LoanProcessManagement.Api/"]
COPY ["src/Infrastructure/LoanProcessManagement.Infrastructure/LoanProcessManagement.Infrastructure.csproj", "src/Infrastructure/LoanProcessManagement.Infrastructure/"]
COPY ["src/Infrastructure/LoanProcessManagement.Identity/LoanProcessManagement.Identity.csproj", "src/Infrastructure/LoanProcessManagement.Identity/"]
RUN dotnet restore "test/LoanProcessManagement.API.IntegrationTests/LoanProcessManagement.API.IntegrationTests.csproj"
COPY . .
WORKDIR "/src/test/LoanProcessManagement.API.IntegrationTests"
RUN dotnet build "LoanProcessManagement.API.IntegrationTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoanProcessManagement.API.IntegrationTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoanProcessManagement.API.IntegrationTests.dll"]
