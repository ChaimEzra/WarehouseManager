using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class UndoCommandInvoker
    {
        public void Execute(IUndoCommand undoCommand, string[] args)
        {
            undoCommand.Execute(args);
        }
    }
}
