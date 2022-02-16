using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .UseSerilog((hostContext, loggerConfiguration) =>
        loggerConfiguration.WriteTo.Console()
            .ReadFrom.Configuration(hostContext.Configuration));

var app = builder.Build();
app.UseSerilogRequestLogging();

app.Run();