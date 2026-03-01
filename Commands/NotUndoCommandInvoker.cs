using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class NotUndoCommandInvoker
    {
        public void Execute(INotUndoCommand notUndoCommand, string[] args) 
        {
            notUndoCommand.Execute(args);
        }
    }
}
