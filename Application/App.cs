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
                Log.Information("Received input: {Input}", input);

                if (input == "")
                {
                    Log.Error("An error occurred while processing input: {Input}", input);
                }
                else
                {
                    string[] inputSplited = input.Split(" ");
                    switch (inputSplited[0])
                    {
                        case "additem":
                            Log.Information("Add command received with arguments:" + input);
                            undoCommandInvoker.Execute(new AddNewItemCommand(), inputSplited.Skip(1).ToArray());
                            break;
                        case "addstock":
                            undoCommandInvoker.Execute(new AddStockCommand(), inputSplited.Skip(1).ToArray()); 
                            break;
                        case "removestock":
                            undoCommandInvoker.Execute(new RemoveStockCommand(), inputSplited.Skip(1).ToArray());
                            break;
                        case "link":
                            notUndoCommandInvoker.Execute(new LinkToFileCommand(), inputSplited.Skip(1).ToArray());
                            break;
                        case "list":
                            notUndoCommandInvoker.Execute(new ListWarehouseCommand(), inputSplited.Skip(1).ToArray());
                            break;
                        case "query":
                            try
                            {
                                //commandInvoker.ExecuteCommand(new QueryCommandF(), input.Split(" "));
                            }
                            catch (Exception ex)
                            {
                                Log.Information("Error run the Query: " + ex.Message);
                            }

                            Log.Information($"q {input}");
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
