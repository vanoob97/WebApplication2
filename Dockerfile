FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY bin/Debug/net5.0/ App/
WORKDIR /App
RUN dotnet restore
ENTRYPOINT ["dotnet", "WebApplication2.dll"]