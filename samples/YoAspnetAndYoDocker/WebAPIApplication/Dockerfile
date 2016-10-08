FROM microsoft/dotnet:1.0.0-core
WORKDIR /app
ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "WebAPIApplication.dll"]
COPY . /app
