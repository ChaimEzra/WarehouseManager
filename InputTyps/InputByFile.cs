using Serilog;
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
            try
            {
                reader = new StreamReader(path);
            }
            catch (Exception)
            {
                string message = $"Failed to open file at path: {path}.";
                Log.Warning(message);
                reader = null;
            }
        }
        public string GetInputString()
        {
            if (reader is null)
            {
                return null;
            }
            if (reader.EndOfStream)
            {
                reader.Close();
                return null;
            }

            return reader.ReadLine();
        }

    }
}
