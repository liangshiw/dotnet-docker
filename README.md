# dotnet-docker
dotnet use docker

## use https

```
 docker run -d -p 8080:80 -p 8081:443 -p 8001:8001 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8081 -e ASPNETCORE_Kestrel__Certificates__Default__Password="crypticpassword" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v C:\Users\admin\.aspnet\https:/https/  [images]
```



