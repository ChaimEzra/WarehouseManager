using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.Commands
{
    internal class CommandInvoker
    {
        //public void Execute(INotUndoCommand notUndoCommand, string[] args) 
        //{
        //    notUndoCommand.Execute(args);
        //}
        private Stack<IUndoCommand> UndoCommands = new Stack<IUndoCommand>();
        public void Execute(IUndoCommand undoCommand, string[] args)
        {
            undoCommand.Execute(args);
            UndoCommands.Push(undoCommand);
        }

        public void Execute(INotUndoCommand undoCommand, string[] args)
        {
            undoCommand.Execute(args);
        }

        public void Undo()
        {
            if (UndoCommands.Count > 0)
            {
                IUndoCommand undoCommand = UndoCommands.Pop();
                undoCommand.Undo();
            }
            else
            {
                Log.Information("No commands to undo.");
            }
        }
    }
}
