using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class RemoveStockCommand : IUndoCommand
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Added stock");
        }
        public void Undo()
        {
            Console.WriteLine("Undoing");
        }
    }
}
