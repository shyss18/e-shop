using EC.AuthService.Web.Extensions;
using Microsoft.AspNetCore.DataProtection;
using Serilog;
using ConfigurationRoot = EC.AuthService.Web.Configurations.ConfigurationRoot;

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

builder.Services.AddDataProtection().DisableAutomaticKeyGeneration();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureIdentityServer(configuration);

//TODO: Configure
builder.Services.AddCors();

var app = builder.Build();
app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();

app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });

app.Run();