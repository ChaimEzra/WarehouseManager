using Serilog;
namespace WarehouseManager.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()
                 .WriteTo.Console()
                 .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                 .CreateLogger();
            try
            {
                Log.Information("Starting application");
                var app = new App();
                app.ShowWelcome();
                app.Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();

            }
        }
       
    }
}
