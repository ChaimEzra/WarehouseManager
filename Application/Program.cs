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
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
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
