using Serilog;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WarehouseManager.Application;

namespace WarehouseManager.WarehouseFolder
{
    internal class Warehouse
    {
        private static Warehouse warehouse;
        public event EventHandler<LowStockEventArgs>? LowStock;
        public Dictionary<Item, int> ItemsInWarehouse { get; private set; }

        private Warehouse()
        {
            ItemsInWarehouse = new Dictionary<Item, int>();
        }
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
            ItemsInWarehouse.Add(item, WarehousSettings.LoadThreshold());
            UpdateQuantity(item.Id);
        }
        public void RemoveItem(int id)
        {
            var item = this.ItemsInWarehouse.Keys.FirstOrDefault(itemId => itemId.Id == id);
            if (item is not null)
            {
                ItemsInWarehouse.Remove(item);
                Log.Information($"The item {item} was removed from warehouse.");
            }
        }

        public void AddStock(int id, int quantity)
        {
            var item = this.ItemsInWarehouse.Keys.FirstOrDefault(itemId => itemId.Id == id);
            if ( item != null )
            {
                this.ItemsInWarehouse[item] += quantity;
                Log.Information($"The quantity {quantity} was successfuly added to item id {id}");
                UpdateQuantity(item.Id);
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
                Log.Information($"The quantity {quantity} was successfuly removed from item id {id}");
                UpdateQuantity(item.Id);
            }
            else
            {
                Log.Error("Item Not found! Id is not valid. Try again");
            }
        }

        public void PrintWarehouse()
        {

            if (this.ItemsInWarehouse.Count > 0)
            {
                foreach (var item in this.ItemsInWarehouse)
                {
                    Console.WriteLine($"[Item: {item.Key} - Quantity: {item.Value}]");
                }
            }
            else
            {
                Log.Warning("Wharehouse empty.");
            }
        }

        public void UpdateQuantity(int id)
        {
            var item = ItemsInWarehouse.Select(i => i.Key).FirstOrDefault(i => i.Id == id);

            if(item is null)
            {
                return;
            }

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
