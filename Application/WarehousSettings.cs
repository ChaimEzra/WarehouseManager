using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Application
{
    internal static class WarehousSettings
    {
        public static IConfigurationRoot Configuration { get; } = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
        public static int Threshold => Configuration.GetValue<int>("LowStockThreshold");


        //public static IConfigurationRoot ConfigurationLoader()
        //{
        //    Configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //            .Build();

        //    Threshold = Configuration.GetValue<int>("LowStockThreshold");

        //    return Configuration;
        //}
        //public static int LoadThreshold()
        //{
        //    //string json = File.ReadAllText("appsettings.json");
        //    //using var doc = JsonDocument.Parse(json);
        //    //return doc.RootElement
        //    //         .GetProperty("LowStockThreshold")
        //    //         .GetInt32();

        //    return ConfigurationLoader().GetValue<int>("LowStockThreshold");

        //}
    }
}
