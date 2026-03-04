using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Commands
{
    internal class AddStockCommand : IUndoCommand
    {
        [Option('i', "id", Required = true, HelpText = "Id of the item to add the quantity to.")]
        public int Id { get; set; }

        [Option('q', "quantity", Required = true, HelpText = "Quantity to add.")]
        public int Quantity { get; set; }

        public void Execute(string[] args) 
        {
            Parser.Default.ParseArguments<AddStockCommand>(args).WithParsed(opts =>
            {
                this.Id = opts.Id;
                this.Quantity = opts.Quantity;

                if (this.Quantity > 0)
                {
                    Warehouse.GetWarehouse().AddStock(this.Id, this.Quantity);
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
