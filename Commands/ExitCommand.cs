using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class ExitCommand : INotUndoCommand
    {
        public void Execute(string[] args)
        {
            //Log.Information("Exiting program.");
        }
    }
}
