using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.InputTyps
{
    internal class InputStringProvider
    {
        public string GetNextCommandString()
        {
            InputByConsole input  = new InputByConsole();
            return input.GetInputString();
             
        }
    }
}
