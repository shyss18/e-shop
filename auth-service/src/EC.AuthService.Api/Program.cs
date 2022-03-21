using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .UseSerilog((hostContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration));

builder.Services.AddIdentityServer();

var app = builder.Build();
app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseIdentityServer();

app.Run();