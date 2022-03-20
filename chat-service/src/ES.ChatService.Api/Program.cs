using ES.ChatService.Api.Extensions;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
builder.Host
    .UseSerilog((hostContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration));
builder.Services.AddValidation();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Run();