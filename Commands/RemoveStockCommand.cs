using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.WarehouseFolder;
using WarehouseManager.Application;
using Serilog;

namespace WarehouseManager.Commands
{
    internal class RemoveStockCommand : IUndoCommand
    {
        [Option('i', "id", Required = true, HelpText = "Id of the item to remove the quantity from.")]
        public int Id { get; set; }

        [Option('q', "quantity", Required = true, HelpText = "Quantity to remove.")]
        public int Quantity { get; set; }

        public void Execute(string[] args)
        {
            Parser.Default.ParseArguments<RemoveStockCommand>(args).WithParsed(opts =>
            {
                this.Id = opts.Id;
                this.Quantity = opts.Quantity;

                if (this.Quantity > 0)
                {
                    Warehouse.GetWarehouse().RemoveStock(this.Id, this.Quantity);
                }
                else
                {
                    Log.Error("The quantity is not valid. Try again.");
                }

            });

        }
        public void Undo()
        {
            Console.WriteLine("Undoing");
        }
    }
}
