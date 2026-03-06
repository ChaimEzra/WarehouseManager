using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.InputTyps
{
    internal class InputByFile : IInputStringGetter
    {
        private StreamReader reader;

        public InputByFile(string path)
        {
            reader = new StreamReader(path);
        }

        public string GetInputString()
        {
            if (reader.EndOfStream)
            {
                reader.Close();
                return null;
            }

            return reader.ReadLine();
        }
        //public string GetInputString()
        //{
        //    return "";
        //}
    }
}
