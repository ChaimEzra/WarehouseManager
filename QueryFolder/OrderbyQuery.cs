using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.QueryFolder
{
    
    internal class OrderbyQuery : IQueryType
    {
        public Func<IEnumerable<Item>, object> Execute(string orderbyString)
        {
            if (string.IsNullOrWhiteSpace(orderbyString))
                return null;
            orderbyString = orderbyString.Trim().ToLower();
            string[] parts = orderbyString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                throw new Exception("Order by string must be in format 'property direction'");

            string propertyName = parts[0];
            string direction = parts[1];
            var prop = GetProperty(propertyName);
            return items =>
            {
                if (direction == "ascending")
                    return items.OrderBy(x => prop.GetValue(x)).ToList();
                else if (direction == "descending")
                    return items.OrderByDescending(x => prop.GetValue(x)).ToList();
                else
                    throw new Exception("Direction must be 'ascending' or 'descending'");
            };

        }
        private PropertyInfo GetProperty(string propertyName)
        {
            var prop = typeof(Item).GetProperty(propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Instance);

            if (prop == null)
                throw new Exception($"Property '{propertyName}' not found");

            return prop;
        }
    }
}
