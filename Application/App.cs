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


                string[] inputSplited = input.Split(" ");
                switch (inputSplited[0])
                {
                    case "additem":
                        undoCommandInvoker.Execute(new AddNewItemCommand(), inputSplited.Skip(1).ToArray());
                        break;
                    case "addstock":

                    case "exit":
                        Log.Information("Exiting application.");
                        return;
                    case "help":
                        notUndoCommandInvoker.Execute(new HelpCommand(), input.Split(" "));
                        break;
                    case "add":
                        Log.Information("Add command received with arguments:" + input);
                        //commandInvoker.ExecuteCommand(new AddItemCommand(), input.Split(" "));
                        break;
                    case "q":
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
                    case "p":
                        Log.Information("Printing the warehouse.");
                        //commandInvoker.ExecuteCommand(new ListWarehouseCommand(), input.Split(" "));
                        break;
                    default:
                        Log.Warning("Unknown command: {Input}", input);
                        break;
                }
                //}
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
