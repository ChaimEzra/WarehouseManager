using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class QueryCommand : INotUndoCommand
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Query");
        }
    }
}
