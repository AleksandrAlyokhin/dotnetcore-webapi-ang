FROM microsoft/dotnet:1.1.0-runtime

WORKDIR /app  
COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet dotnetcore-webapi-ang.dll