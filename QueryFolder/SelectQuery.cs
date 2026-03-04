using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.QueryFolder
{
    
    internal class SelectQuery : IQueryType
    {
        public Func<IEnumerable<Item>, object> Execute(string selectString)
        {
            if (string.IsNullOrWhiteSpace(selectString))
                throw new ArgumentException("Select string is empty");

            selectString = selectString.Trim().ToLower();

            if (selectString.StartsWith("avg(") && selectString.EndsWith(")"))
            {
                string property = ExtractProperty(selectString, "avg");

                return items =>
                {
                    var prop = GetProperty(property);

                    return items.Average(x =>
                        Convert.ToDouble(prop.GetValue(x)));
                };
            }
            if (selectString.StartsWith("sum(") && selectString.EndsWith(")"))
            {
                string property = ExtractProperty(selectString, "sum");

                return items =>
                {
                    var prop = GetProperty(property);

                    return items.Sum(x =>
                        Convert.ToDouble(prop.GetValue(x)));
                };
            }
            if (selectString == "*")
            {
                return items => items.ToList();
            }

            return items =>
            {
                var prop = GetProperty(selectString);

                return items
                    .Select(x => prop.GetValue(x))
                    .ToList();
            };
        }
        private string ExtractProperty(string input, string keyword)
        {
            return input
                .Replace(keyword + "(", "")
                .Replace(")", "")
                .Trim();
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
