using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.QueryFolder
{
    
    internal class WhereQuery : IQueryType
    {
        private readonly string[] Operators =
        {
            ">=",
            "<=",
            "==",
            "!=",
            ">",
            "<"
        };
        public Func<IEnumerable<Item>, object> Execute(string queryTypeString)
        {
            var orGroups = queryTypeString.Split("||");

            return (items) =>
            {
                return items.Where(item =>
                {
                    foreach (var gruop in orGroups)
                    {
                        var andConditions = gruop.Split("&&");

                        bool allTrue = true;

                        foreach (var condition in andConditions)
                        {
                            if (!EvaluateCondition(item, condition))
                            {
                                allTrue = false;
                                break;
                            }
                        }

                        if (allTrue)
                            return true;
                    }

                    return false;
                });
            };
            //return items => items;
        }
        private bool EvaluateCondition(Item item, string condition)
        {
            condition = condition.Trim().ToLower();

            foreach (var op in Operators)
            {
                if (condition.Contains(op))
                {
                    var parts = condition.Split(op);

                    var left = parts[0].Trim();
                    var right = parts[1].Trim();

                    var prop = GetProperty(left);
                    var value = prop.GetValue(item);

                    return Compare(value, right, op);
                }
            }

            return CheckEnumProperty(item, condition);
        }
        private bool Compare(object itemValue, string rightSide, string op)
        {
            if (itemValue is double or int)
            {
                double leftNumber = Convert.ToDouble(itemValue);
                double rightNumber = double.Parse(rightSide);

                return op switch
                {
                    ">" => leftNumber > rightNumber,
                    "<" => leftNumber < rightNumber,
                    ">=" => leftNumber >= rightNumber,
                    "<=" => leftNumber <= rightNumber,
                    "==" => leftNumber == rightNumber,
                    "!=" => leftNumber != rightNumber,
                    _ => false
                };
            }

            if (itemValue is string)
            {
                return op switch
                {
                    "==" => itemValue.ToString().ToLower() == rightSide,
                    "!=" => itemValue.ToString().ToLower() != rightSide,
                    _ => false
                };
            }

            return false;
        }
        private bool CheckEnumProperty(Item item, string condition)
        {
            if (Enum.TryParse(typeof(ItemProperty), condition, true, out var enumValue))
            {
                return item.Properties.Contains((ItemProperty)enumValue);
            }

            throw new Exception($"Invalid condition: {condition}");
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
