using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.QueryFolder
{
    internal interface IQueryType
    {
        Func<IEnumerable<Item>, object> Execute(string queryTypeString);

    }
}
