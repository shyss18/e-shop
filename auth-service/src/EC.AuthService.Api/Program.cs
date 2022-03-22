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
    .AddControllers();

builder.Services
    .AddIdentityServer(options =>
    {
        options.IssuerUri = configuration["IdentityServer:IssuerUri"];
        options.UserInteraction.LoginUrl = configuration["IdentityServer:LoginUrl"];
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
        options.Events.RaiseInformationEvents = true;
    })
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(IdentityResources.Get)
    .AddInMemoryApiScopes(ApiScopes.Get)
    .AddInMemoryClients(Clients.Get(configuration.Get<ClientsConfiguration>()));

builder.Services
    .AddAuthentication();

//TODO: Configure
builder.Services.AddCors();

var app = builder.Build();
app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();

app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });

app.Run();