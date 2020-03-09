FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /build
COPY DbMigrator.csproj ./
RUN dotnet restore 
COPY . .
RUN dotnet publish -o /publish 
WORKDIR /publish 
#ENTRYPOINT ["dotnet", "DbMigrator.dll"]
CMD ["sh", "-c", "dotnet DbMigrator.dll \"${DB_CONNECTION}\""]
