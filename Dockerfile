FROM mcr.microsoft.com/dotnet/aspnet:5.0
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=”development”
EXPOSE 5000
WORKDIR /app
COPY ./dist .
ENTRYPOINT ["dotnet", "WebApplication2.dll"]