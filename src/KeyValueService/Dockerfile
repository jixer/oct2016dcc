FROM microsoft/dotnet:1.0.0-preview2-sdk

WORKDIR /build/KeyValueService
COPY . .
RUN dotnet restore && \
    dotnet build -c Release -o /app --framework .NETCoreApp,Version=v1.0;

RUN mkdir /app/_Data && \
    echo '' > /app/_Data/values.dat;

WORKDIR /app
ENV ASPNETCORE_URLS http://*:3000
EXPOSE 3000
ENTRYPOINT ["dotnet", "KeyValueService.dll"]