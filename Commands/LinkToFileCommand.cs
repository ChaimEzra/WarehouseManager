using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class LinkToFileCommand : INotUndoCommand
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Link to a file.");
        }
    }
}
