using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Warehouse
{
    internal class Item
    {
        private static int CounterId { get; set; } 
        public int Id { get; }
        public string Name { get; set; }
            
        public Item() 
        {
            this.Id = ++CounterId;
        }
    }
}
