FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
EXPOSE 80
COPY . /publish .
ENTRYPOINT ["dotnet","MasterDataService.dll"]
