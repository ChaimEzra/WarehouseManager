using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Warehouse
{
    internal class Warehouse
    {
        private static Warehouse warehouse;
        public static Warehouse GetWarehouse()
        {
            if (warehouse is null)
            {
                warehouse = new Warehouse();
            }
            return warehouse;
        }
    }
}
