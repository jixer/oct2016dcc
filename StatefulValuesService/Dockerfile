FROM microsoft/dotnet:1.0.0-preview2-sdk

WORKDIR /build/StatefulValuesService
COPY . /build/StatefulValuesService
RUN dotnet restore && \
    dotnet build -c Release -o /app --framework .NETCoreApp,Version=v1.0;

WORKDIR /app
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "StatefulValuesService.dll"]