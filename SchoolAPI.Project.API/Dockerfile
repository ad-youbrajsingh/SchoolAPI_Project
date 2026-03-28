FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["SchoolAPI.Project.API/SchoolAPI.Project.API.csproj","SchoolAPI.Project.API/"]
COPY ["SchoolAPI.Project.Application/SchoolAPI.Project.Application.csproj","SchoolAPI.Project.Application/"]
COPY ["SchoolAPI.Project.Domain/SchoolAPI.Project.Domain.csproj","SchoolAPI.Project.Domain/"]
COPY ["SchoolAPI.Project.Infrastructure/SchoolAPI.Project.Infrastructure.csproj","SchoolAPI.Project.Infrastructure/"]

RUN dotnet restore "SchoolAPI.Project.API/SchoolAPI.Project.API.csproj"

COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5000

ENTRYPOINT [ "dotnet","SchoolAPI.Project.API.dll" ]
