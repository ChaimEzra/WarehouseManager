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
            if ( item != null )
            {
                this.ItemsInWarehouse[item] += quantity;
                Log.Information($"The quantity {quantity} was successfuly added to item id {id}");
            }else
            {
                Log.Error("Item Not found! Id is not valid. Try again");
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
