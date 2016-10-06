FROM microsoft/dotnet:1.0.0-core
WORKDIR /app
ENV ASPNETCORE_URLS http://*:3000
EXPOSE 3000
ENTRYPOINT ["dotnet", "KeyValueService.dll"]
COPY . /app
