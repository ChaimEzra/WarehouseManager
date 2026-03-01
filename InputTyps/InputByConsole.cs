using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.InputTyps
{
    internal class InputByConsole : IInputStringGetter
    {
        public string GetInputString()
        {
            Console.Write("Warehouse>");
            string ? input = Console.ReadLine();
            return input;
        }
    }
}
