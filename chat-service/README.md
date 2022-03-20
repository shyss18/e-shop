# Chat service

## Version 1.0 use cases:

- Sending messages between two users

# How to run

Before running an application, you need to configure dev certificates(running from IDE), so run following commands:<br />
`dotnet dev-certs https --clean`<br />
`dotnet dev-certs https`<br />
`dotnet dev-certs https --trust`<br />

If you want to run docker-compose, you will need to configure another certificates:<br />

### Windows

`dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p { password here }`<br />
`dotnet dev-certs https --trust` <br />

### macOS or Linux

`dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p { password here }`<br />
`dotnet dev-certs https --trust`<br />

In the preceding commands, replace `{ password here }` with a password.<br />
In docker-compose file change:<br />

`- ASPNETCORE_Kestrel__Certificates__Default__Password` - with your password

Then go to deploy folder, open cmd/PowerShell/bash/etc. and run:<br />

`docker-compose -f "docker-compose.yml" -p chat-service-container up -d`
