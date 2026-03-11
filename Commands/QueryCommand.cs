using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.QueryFolder;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Commands
{
    internal class QueryCommand : INotUndoCommand
    {
        public void Execute(string[] args)
        {
            string query = string.Join(" ", args);
            QueryParser parser = new QueryParser();
            Query q = parser.Parse(query);

            try
            {

                var whereFunc = new WhereQuery().Execute(q.WherePart);
                var selectFunc = new SelectQuery().Execute(q.SelectPart);
                var orderbyFunc = new OrderbyQuery().Execute(q.OrderByPart);

                var whereResult = whereFunc(Warehouse.GetWarehouse().ItemsInWarehouse.Keys);
                var orderResult = orderbyFunc((IEnumerable<Item>)whereResult);
                var selectResult = selectFunc((IEnumerable<Item>)orderResult);

                if (selectResult is IEnumerable<object> enumerable)
                {
                    foreach (var item in enumerable)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine(selectResult);
                }
            }
            catch (Exception ex)
            {
                Log.Information("Erorr in query command:" + ex.Message);
            }
        }
    }
}
