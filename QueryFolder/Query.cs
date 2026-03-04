using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.QueryFolder
{
    
    internal class Query
    {
        public string ? SelectPart { get; set; }
        public string ? WherePart { get; set; }
        public string ? OrderByPart { get; set; }

        public override string ToString()
        {
            return $"SELECT: {this.SelectPart}\nWHERE: {this.WherePart}\nORDER BY: {this.OrderByPart}";
        }
    }
}
