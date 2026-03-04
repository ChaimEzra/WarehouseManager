using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Commands
{
    internal class AddNewItemCommand : IUndoCommand
    {
        [Option('n', "name", Required = true, HelpText = "Name of the product.")]
        public string ? Name { get; set; }

        [Option('p', "price", Required = true, HelpText = "Price of the product.")]
        public double Price { get; set; }

        [Option('t', "traits", Required = false, Separator = ',', HelpText = "Proprtyes to enter if true")]
        public IEnumerable<ItemProperty> ? Traits { get; set; }

        public void Execute(string[] args)
        {
            Parser.Default.ParseArguments<AddNewItemCommand>(args).WithParsed(opts =>
            {
                HashSet<ItemProperty> itemProperties = new HashSet<ItemProperty>();

                if (opts.Traits != null)
                {
                    foreach (var trait in opts.Traits)
                    {
                        itemProperties.Add(trait);
                    }
                }
                
                Warehouse.GetWarehouse().AddnewItem(new Item(opts.Name, opts.Price,itemProperties));
                Log.Information("New Item Added to the warehouse");
            });
            
        }
        public void Undo()
        {
            Console.WriteLine("Undoing");
        }
    }
}
