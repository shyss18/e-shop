using ES.ChatService.Api.Extensions;
using ES.ChatService.Api.Hubs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .UseSerilog((hostContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration));

builder.Services.AddCors();
builder.Services.AddSignalR();
builder.Services.AddValidation();

var app = builder.Build();

//TODO: Configure cors
app.UseCors(cors => cors
    .WithOrigins("*")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.MapHub<ChatHub>("/chat");

app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Run();