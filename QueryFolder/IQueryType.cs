using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.QueryFolder
{
    /// <summary>
    /// Interface for query operations (Select / Where / OrderBy).
    /// Each query type gets the raw query string and returns a function
    /// that runs on a collection of Items.
    /// </summary>
    internal interface IQueryType
    {
        Func<IEnumerable<Item>, object> Execute(string queryTypeString);

    }
}
