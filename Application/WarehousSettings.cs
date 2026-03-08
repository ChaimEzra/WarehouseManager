using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Application
{
    internal  static class WarehousSettings
    {       
        public static int LoadThreshold()
        {
            string json = File.ReadAllText("appsettings.json");
            using var doc = JsonDocument.Parse(json);

            return doc.RootElement
                      .GetProperty("LowStockThreshold")
                      .GetInt32();
        }
    }
}
