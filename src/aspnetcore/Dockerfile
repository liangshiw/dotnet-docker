FROM microsoft/dotnet:2.1-sdk
WORKDIR /app
EXPOSE 5000 5001 443 80
COPY / /app
COPY cmd.sh /

CMD ["/cmd.sh"]
