using ES.ProductService.Api.Extensions;
using ES.ProductService.Infrastructure.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .UseSerilog((hostContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration));

builder.Services
    .AddMediatrSupport()
    .AddDbSupport(builder.Configuration)
    .AddAutoMapper(typeof(Program), typeof(ApplicationContext))
    .AddControllers();

var app = builder.Build();
app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();