using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.Application;

namespace WarehouseManager.WarehouseFolder
{
    internal class Warehouse
    {
        private static Warehouse warehouse;
        public Dictionary<Item, int> ItemsInWarehouse { get; private set; } = new Dictionary<Item, int>();
        private Warehouse() 
        {
          
        }
       
        public static Warehouse GetWarehouse()
        {
            if (warehouse is null)
            {
                warehouse = new Warehouse();
                //warehouse.LowStock += OnLowStock;
            }
            return warehouse;
        }
        public void AddnewItem(Item item)
        {
            ItemsInWarehouse.Add(item, WarehousSettings.LoadThreshold());
            UpdateQuantity(item);
        }
        public void AddStock(int id, int quantity)
        {
            var item = this.ItemsInWarehouse.Keys.FirstOrDefault(itemId => itemId.Id == id);
            if ( item != null )
            {
                this.ItemsInWarehouse[item] += quantity;
                Log.Information($"The quantity {quantity} was successfuly added to item id {id}");
                UpdateQuantity(item);
            }
            else
            {
                Log.Error("Item Not found! Id is not valid. Try again");
            }
        }
        public void RemoveStock(int id, int quantity)
        {
            var item = this.ItemsInWarehouse.Keys.FirstOrDefault(itemId => itemId.Id == id);
            if (item != null)
            {
                if(quantity > this.ItemsInWarehouse[item])
                {
                    Log.Error($"Not enough stock for item id {id}. Current quantity: {this.ItemsInWarehouse[item]}");
                    return;
                }
                this.ItemsInWarehouse[item] -= quantity;
                UpdateQuantity(item);
                Log.Information($"The quantity {quantity} was successfuly added to item id {id}");
            }
            else
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
        }
        public event EventHandler<LowStockEventArgs>? LowStock;

        public void UpdateQuantity(Item item)
        {
            if (!ItemsInWarehouse.ContainsKey(item))
                throw new Exception("Item not found");

            int newQuantity = ItemsInWarehouse[item];

            int threshold = WarehousSettings.LoadThreshold();

            bool isBelow = newQuantity < threshold;

            if (isBelow)
            {
                OnLowStock(item, newQuantity, threshold);
            }
        }

        protected virtual void OnLowStock(Item item, int quantity, int threshold)
        {
            LowStock?.Invoke(this, new LowStockEventArgs(item, quantity, threshold));
        }
    }
}
