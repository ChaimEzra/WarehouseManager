using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Commands
{
    internal class ListWarehouseCommand : INotUndoCommand
    {
        public void Execute(string[] args)
        {
            Warehouse.GetWarehouse().PrintWarehouse();

        }
    }
}
