using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.WarehouseFolder
{
    public class LowStockEventArgs : EventArgs
    {
        public Item Item { get; }
        public int Quantity { get; }
        public int Threshold { get; }

        public LowStockEventArgs(Item item, int quantity, int threshold)
        {
            Item = item;
            Quantity = quantity;
            Threshold = threshold;
        }
    }
}
