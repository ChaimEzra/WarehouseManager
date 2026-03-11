using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.Commands;
using WarehouseManager.InputTyps;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Application
{
    internal class App
    {
        public void Run()
        {
            InputStringProvider inputStringProvider = new InputStringProvider();
            //UndoCommandInvoker undoCommandInvoker = new UndoCommandInvoker();
            CommandInvoker CommandInvoker = new CommandInvoker();
            ShowWelcome();

            while (true)
            {
                string input = inputStringProvider.GetNextCommandString().ToLower();

                string inputToComper = input.Split(" ")[0];
                string[] args = input.Split(" ").Skip(1).ToArray();

                switch (inputToComper)
                {
                    case "additem":
                        CommandInvoker.Execute(new AddNewItemCommand(), args);
                        break;
                    case "addstock":
                        CommandInvoker.Execute(new AddStockCommand(), args);
                        break;
                    case "removestock":
                        CommandInvoker.Execute(new RemoveStockCommand(), args);
                        break;
                    case "undo":
                        CommandInvoker.Execute(new UndoCommand(CommandInvoker), args);
                        break;
                    case "link":
                        CommandInvoker.Execute(new LinkToFileCommand(inputStringProvider), args);
                        break;
                    case "list":
                        CommandInvoker.Execute(new ListWarehouseCommand(), args);
                        break;
                    case "query":
                        CommandInvoker.Execute(new QueryCommand(), args);
                        break;
                    case "help":
                        CommandInvoker.Execute(new HelpCommand(), args);
                        break;
                    case "exit":
                        CommandInvoker.Execute(new ExitCommand(), args);
                        Log.Information("Exiting application.");
                        return;
                    default:
                        Log.Warning($"Unknown command: {input}");
                        break;
                }

            }
        }
        private static void ShowWelcome()
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
