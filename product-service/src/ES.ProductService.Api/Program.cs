using ES.ProductService.Api.Extensions;
using ES.ProductService.Api.PipelineBehavior;
using ES.ProductService.Application.Commands.CreateProduct;
using ES.ProductService.Infrastructure.Context;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .UseSerilog((hostContext, loggerConfiguration) =>
        loggerConfiguration.WriteTo.Console()
            .ReadFrom.Configuration(hostContext.Configuration));

builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateProductCommand));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

builder.Services.AddAutoMapper(typeof(Program), typeof(ApplicationContext));

builder.Services.AddDbSupport(builder.Configuration);

var app = builder.Build();
app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();