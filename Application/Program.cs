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
        //public static void Main(string[] args)
        //{
        //    while (true)
        //    {
        //        int choice = int.Parse(Console.ReadLine());
        //        int n =  WarehousSettings.LoadThreshold();
        //        Console.WriteLine($"You choice {choice} + trashholde {n} = {choice + n}");
        //    }
        //}
    }
}
