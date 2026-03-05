using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class ExitCommand : INotUndoCommand
    {
        public void Execute(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
