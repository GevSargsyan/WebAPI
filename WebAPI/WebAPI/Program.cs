using Serilog;
using WebAPI.LoggingConfigurations;
using WebAPI.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

LoggingConfiguration.ConfigureLogging();

builder.Host.UseSerilog();


var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run(async (context) =>
{

    throw new Exception("Test");
    await context.Response.WriteAsync("Main");
});
app.Lifetime.ApplicationStopped.Register(Log.CloseAndFlush);
app.Run();


