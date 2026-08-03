FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["taskManagement/taskManagementApi.csproj", "taskManagement/"]
COPY ["taskManagement.entity/taskManagementDomain.csproj", "taskManagement.entity/"]
COPY ["TaskManagmentApplication/TaskManagmentApplication.csproj", "TaskManagmentApplication/"]
COPY ["TaslManagementinfratstructure/TaslManagementinfrastructure.csproj", "TaslManagementinfratstructure/"]

RUN dotnet restore "taskManagement/taskManagementApi.csproj"

COPY . .

RUN dotnet build "taskManagement/taskManagementApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "taskManagement/taskManagementApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "taskManagementApi.dll"]