using Microsoft.Extensions.Configuration;
using Serilog;
using WarehouseManager.WarehouseFolder;
namespace WarehouseManager.Application
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EventMessageService eventMessageService = new EventMessageService(Warehouse.GetWarehouse());


            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(WarehousSettings.Configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting application");
                var app = new App();
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
