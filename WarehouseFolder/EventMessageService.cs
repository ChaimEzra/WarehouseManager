using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.WarehouseFolder
{
    internal class EventMessageService
    {
        public EventMessageService(Warehouse warehouse) 
        {
             warehouse.LowStock += OnLowStock;
        }
        private void OnLowStock(object? sender, LowStockEventArgs e)
        {
            Log.Warning($"Alert! Item: {e.Item} quantity about to finish.");
        }
    }
}
