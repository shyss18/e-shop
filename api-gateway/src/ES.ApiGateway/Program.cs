using Serilog;

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

//TODO: Configure
builder.Services.AddCors();

var app = builder.Build();
app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}