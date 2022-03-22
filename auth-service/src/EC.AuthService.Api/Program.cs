using EC.AuthService.Api.Configurations;
using EC.AuthService.Api.IS4Configurations;
using Serilog;
using ConfigurationRoot = EC.AuthService.Api.Configurations.ConfigurationRoot;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .ConfigureAppConfiguration(configBuilder =>
    {
        var path = Directory.GetCurrentDirectory();
        configBuilder
            .SetBasePath(path)
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false);
    })
    .UseSerilog((hostContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration));

var configuration = ConfigurationRoot.Get(Directory.GetCurrentDirectory(), builder.Environment.EnvironmentName);

builder.Services
    .AddIdentityServer()
    .AddInMemoryApiScopes(ApiScopes.Get)
    .AddInMemoryClients(Clients.Get(configuration.Get<ClientsConfiguration>()));

var app = builder.Build();
app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseIdentityServer();

app.Run();