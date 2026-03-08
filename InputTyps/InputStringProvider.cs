using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.InputTyps
{
    internal class InputStringProvider
    {
        private Stack<IInputStringGetter> inputStack = new Stack<IInputStringGetter>();
        public InputStringProvider()
        {
            inputStack.Push(new InputByConsole());
        }

        public void PushInput(IInputStringGetter input)
        {
            inputStack.Push(input);
        }

        public string GetNextCommandString()
        {
            while (true)
            {
                string command = inputStack.Peek().GetInputString();

                if (!string.IsNullOrWhiteSpace(command))
                {
                    return command;
                }
               

                if (command is null && inputStack.Count > 1)
                {
                    inputStack.Pop();
                    continue;
                }
                if (command == "" && inputStack.Count <= 1)
                {
                    Log.Error("Input can't be empty");
                }
            }
        }
    }
}
