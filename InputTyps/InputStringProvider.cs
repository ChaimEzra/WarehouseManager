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
            while (inputStack.Count > 0)
            {
                string command = inputStack.Peek().GetInputString();

                if (command != null)
                    return command;

                inputStack.Pop();
            }

            return "";
        }
        //public string GetNextCommandString()
        //{
        //    InputByConsole input  = new InputByConsole();
        //    return input.GetInputString();
             
        //}
    }
}
