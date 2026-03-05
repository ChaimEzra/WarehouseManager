using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.WarehouseFolder
{
    internal class Item
    {
        private static int CounterId { get; set; } = 0;
        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public HashSet<ItemProperty> Properties { get; set; } 
        public Item(string Name, double Price, HashSet<ItemProperty> Properties) 
        {
            this.Id = ++CounterId;
            this.Name = Name;
            this.Price = Price;
            this.Properties = Properties;
        }
        public bool HasProperty(ItemProperty prop)
        {
            return this.Properties.Contains(prop);
        }
        public override string ToString()
        {
            return $"<Id: {this.Id}, Name: {this.Name}, Price: {this.Price}, Properties: {string.Join(", ", this.Properties)}>";
        }
    }
}
