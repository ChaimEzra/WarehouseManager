using Serilog;
using WarehouseManager.WarehouseFolder;
namespace WarehouseManager.Application
{
    internal class Program
    {
        public static void Main(string[] args)
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
        //public static void Main(string[] args)
        //{
        //    Warehouse w = Warehouse.GetWarehouse();
        //    var item = new Item("a", 5.5, new HashSet<ItemProperty>(new[] { ItemProperty.Fragile, ItemProperty.Needscooling }));
        //    w.AddnewItem(item);
        //    w.AddnewItem(new Item("b", 5, new HashSet<ItemProperty>(new[] { ItemProperty.Fragile, ItemProperty.Needscooling })));
        //    w.AddnewItem(new Item("c", 50, new HashSet<ItemProperty>(new[] { ItemProperty.Fragile, ItemProperty.Edible })));
        //    w.AddnewItem(new Item("r", 55, new HashSet<ItemProperty>(new[] { ItemProperty.Fragile })));

        //    w.AddStock(item.Id + -1, 2000000000);
        //    w.PrintWarehouse();

        //}
    }
}
