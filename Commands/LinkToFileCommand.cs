using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WarehouseManager.InputTyps;
using WarehouseManager.WarehouseFolder;

namespace WarehouseManager.Commands
{
    internal class LinkToFileCommand : INotUndoCommand
    {
        [Option('p', "path", Required = true, HelpText = "Full path to the file commands.")]
        public string? Path { get; set; }

        private InputStringProvider provider;

        public LinkToFileCommand() { }
        public LinkToFileCommand(InputStringProvider provider)
        {
            this.provider = provider;
        }
        

        public void Execute(string[] args)
        {
            Parser.Default.ParseArguments<LinkToFileCommand>(args).WithParsed(opts =>
            {
                provider.PushInput(new InputByFile(opts.Path));
            });

         
        }
       
    }
}
