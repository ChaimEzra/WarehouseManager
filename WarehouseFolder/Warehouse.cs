using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.WarehouseFolder
{
    internal class Warehouse
    {
        private static Warehouse warehouse;
        public Dictionary<Item, int> ItemsInWarehouse { get; private set; } = new Dictionary<Item, int>();
        public static Warehouse GetWarehouse()
        {
            if (warehouse is null)
            {
                warehouse = new Warehouse();
            }
            return warehouse;
        }
        public void AddnewItem(Item item)
        {
            ItemsInWarehouse.Add(item, 1);
        }
        public void AddStock(int id, int quantity)
        {
            var item = this.ItemsInWarehouse.Keys.FirstOrDefault(itemId => itemId.Id == id);
            if ( item != null && quantity > 0)
            {
                this.ItemsInWarehouse[item] += quantity;
            }else
            {
                Console.WriteLine("Item Not found");
                Log.Error("Id or Quantity are not valid. Try again");
            }
        }
        public void PrintWarehouse()
        {
            
            foreach (var item in this.ItemsInWarehouse)
            {
                Console.WriteLine($"[Item: {item.Key} - Quantity: {item.Value}]");
            }
            
            //this.ItemsInWarehouse.Select(item => 
            //item.Key )
            //    .ToList()
            //    .ForEach(item => Console.WriteLine(item));
        }
    }
}
