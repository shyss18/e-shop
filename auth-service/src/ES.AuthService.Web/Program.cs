using System.Reflection;
using ES.AuthService.Infrastructure;
using ES.AuthService.Web.Extensions;
using ES.AuthService.Application.SignIn.Commands;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ConfigurationRoot = ES.AuthService.Infrastructure.ConfigurationRoot;

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
    .AddDbContext<ApplicationContext>(options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("IdentityServerContext"));
    });

builder.Services.AddMediatR(typeof(SignInCommand).Assembly);
builder.Services.AddAutoMapper(Assembly.GetCallingAssembly());

builder.Services.AddDataProtection().DisableAutomaticKeyGeneration();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureIdentity(configuration);
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
app.UseAuthentication();
app.UseIdentityServer();

app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });

app.Run();