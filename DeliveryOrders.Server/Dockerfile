#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["deliveryorders.client/nuget.config", "deliveryorders.client/"]
COPY ["DeliveryOrders.Server/DeliveryOrders.Server.csproj", "DeliveryOrders.Server/"]
COPY ["deliveryorders.client/deliveryorders.client.esproj", "deliveryorders.client/"]
COPY ["DeliveryOrders.DataAccess/DeliveryOrders.DataAccess.csproj", "DeliveryOrders.DataAccess/"]
COPY ["DeliveryOrders.Repository/DeliveryOrders.Repository.csproj", "DeliveryOrders.Repository/"]
RUN dotnet restore "./DeliveryOrders.Server/DeliveryOrders.Server.csproj"
COPY . .
WORKDIR "/src/DeliveryOrders.Server"
RUN dotnet build "./DeliveryOrders.Server.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DeliveryOrders.Server.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeliveryOrders.Server.dll"]