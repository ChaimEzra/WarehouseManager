using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class HelpCommand : INotUndoCommand
    {
        public void Execute(string[] args)
        {
            ShowHelp();
        }
        private void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========== AVAILABLE COMMANDS ==========\n");

            Console.WriteLine("AddItem -n <Name> -p <Price> -t <Edible,Needscooling,Fragile>");
            Console.WriteLine("    Adds a new item to the warehouse.");
            Console.WriteLine("    Example: AddItem -n Apple -p 5.5 -t Fragile,Needscooling\n");
        
            Console.WriteLine("AddStock -i <ItemId> -q <Quantity>");
            Console.WriteLine("    Increases stock of an existing item.");
            Console.WriteLine("    Example: AddStock -i 1 -q 20\n");

            Console.WriteLine("RemoveStock -i <ItemId> -q <Quantity>");
            Console.WriteLine("    Decreases stock of an existing item.");
            Console.WriteLine("    Example: RemoveStock -i 1 -q 5\n");

            Console.WriteLine("Undo");
            Console.WriteLine("    Undoing the last Command.\n");

            Console.WriteLine("List");
            Console.WriteLine("    Displays all items in the warehouse.\n");

            Console.WriteLine("Link -f <FilePath>");
            Console.WriteLine("    Loads Commands data from file.\n");

            Console.WriteLine("Query Select Avg(price)/Sum(price)/Name Where [Condition] (Optional query) Orderby prop Descending/Ascending");
            Console.WriteLine("Condition => price >= 20 && Fragile || Heavy ....");
            Console.WriteLine("    Executes a query on warehouse items.");
            Console.WriteLine("    Example: Query Select name Where price > 10 Orderby price ascending\n");

            Console.WriteLine("Help");
            Console.WriteLine("    Show this page.\n");

            Console.WriteLine("Exit");
            Console.WriteLine("    Closes the application.\n");

            Console.WriteLine("=========================================");
            Console.ResetColor();

        }
    }
}
