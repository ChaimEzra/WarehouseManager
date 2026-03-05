using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        public IEnumerable<string>? Traits { get; set; } = new List<string>();

        public void Execute(string[] args)
        {
            Parser.Default.ParseArguments<AddNewItemCommand>(args).WithParsed(opts =>
            {
                HashSet<ItemProperty> itemProperties = new HashSet<ItemProperty>();

                if (opts.Traits != null)
                {
                    foreach (var trait in opts.Traits)
                    {
                        if (Enum.TryParse<ItemProperty>(trait, ignoreCase: true, out ItemProperty result))
                        {
                            itemProperties.Add(result);
                        }else
                        {
                            Log.Error($"Invalid trait: {trait}. Skipping.");
                            return;
                        }
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
