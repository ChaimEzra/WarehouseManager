using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class AddNewItemCommand : IUndoCommand
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Add item.");
        }
    }
}
