using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Application
{
    internal class WarehousSettings
    {
        private static WarehousSettings warehouseSettings;
        public static WarehousSettings GetWarehousSettings()
        {
            if (warehouseSettings is null)
            {
                warehouseSettings = new WarehousSettings();
            }
            return warehouseSettings;
        }
        public static int LoadThreshold()
        {
            string json = File.ReadAllText("C:\\Users\\chaim\\Desktop\\C#\\WarehouseManager\\appsettings.json");

            var doc = JsonDocument.Parse(json);

            return doc.RootElement
                      .GetProperty("LowStockThreshold")
                      .GetInt32();
        }
    }
}
