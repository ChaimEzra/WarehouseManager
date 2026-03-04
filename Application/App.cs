using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.Commands;
using WarehouseManager.InputTyps;

namespace WarehouseManager.Application
{
    internal class App
    {
        public void Run()
        {
            InputStringProvider inputStringProvider = new InputStringProvider();
            UndoCommandInvoker undoCommandInvoker = new UndoCommandInvoker();
            NotUndoCommandInvoker notUndoCommandInvoker = new NotUndoCommandInvoker();

            while (true)
            {
                string input = inputStringProvider.GetNextCommandString().ToLower();

                if (input == "")
                {
                    Log.Error("Input can't be empty");
                }
                else
                {
                    string inputToComper = input.Split(" ")[0];
                    string[] args = input.Split(" ").Skip(1).ToArray();

                    switch (inputToComper)
                    {
                        case "additem":
                            undoCommandInvoker.Execute(new AddNewItemCommand(), args);
                            break;
                        case "addstock":
                            undoCommandInvoker.Execute(new AddStockCommand(), args); 
                            break;
                        case "removestock":
                            undoCommandInvoker.Execute(new RemoveStockCommand(), args);
                            break;
                        case "undo":
                            notUndoCommandInvoker.Execute(new UndoCommand(), args);
                            break;
                        case "link":
                            notUndoCommandInvoker.Execute(new LinkToFileCommand(), args);
                            break;
                        case "list":
                            notUndoCommandInvoker.Execute(new ListWarehouseCommand(), args);
                            break;
                        case "query":
                            notUndoCommandInvoker.Execute(new QueryCommand(), args);
                            break;
                        case "help":
                            notUndoCommandInvoker.Execute(new HelpCommand(), input.Split(" "));
                            break;
                        case "exit":
                            Log.Information("Exiting application.");
                            return;
                        default:
                            Log.Warning($"Unknown command: {input}");
                            break;
                    }
                }
            }
        }
        public void ShowWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================");
            Console.WriteLine("     WAREHOUSE MANAGEMENT SYSTEM      ");
            Console.WriteLine("======================================");
            Console.WriteLine("Type HELP to see available commands.");
            Console.WriteLine("Type EXIT to close the application.");
            Console.ResetColor();
        }
    }
}
