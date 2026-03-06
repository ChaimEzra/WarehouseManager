using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class UndoCommand : INotUndoCommand
    {
        private UndoCommandInvoker UndoCommandInvoker;
        public UndoCommand(UndoCommandInvoker undoCommandInvoker)
        {
            this.UndoCommandInvoker = undoCommandInvoker;
        }
        public void Execute(string[] args)
        {
            Log.Information("Undoing last command.");
            this.UndoCommandInvoker.Undo();
            
        }
    }
}
