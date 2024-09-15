using Serilog;

namespace WebAPI.LoggingConfigurations
{
    public static class LoggingConfiguration
    {
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Information()
                        .WriteTo.File("logs/info_log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, outputTemplate:
                        $"{{Timestamp:yyyy-MM-dd HH:mm:ss}} [{{Level:u3}}] {{Message:lj}}{{NewLine}}{{NewLine}}{new string('=', 150)}{{NewLine}}")
                        .WriteTo.File("logs/error_log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error, outputTemplate:
                        $"{{Timestamp:yyyy-MM-dd HH:mm:ss}} [{{Level:u3}}] {{Message:lj}}{{NewLine}}{{Exception}}{{NewLine}}{new string('=', 150)}{{NewLine}}") 
                        .CreateLogger();
        }

    }
}

