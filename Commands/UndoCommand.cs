using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class UndoCommand : INotUndoCommand
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Undo");
        }
    }
}
