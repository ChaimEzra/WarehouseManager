using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal interface INotUndoCommand
    {
        void Execute(string[] args);
    }
}
