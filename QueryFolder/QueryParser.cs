using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManager.QueryFolder
{
    
    internal class QueryParser
    {
        public Query Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Log.Error("Query cannot be empty");
                return null;
            }
            else
            {
                Query query = new Query();

                string lower = input.ToLower();

                int selectIndex = lower.IndexOf("select");
                int whereIndex = lower.IndexOf("where");
                int orderIndex = lower.IndexOf("orderby");

                // SELECT
                if (selectIndex == -1)
                {
                    Log.Error("Query must contain SELECT");
                    return null;
                }
                if (whereIndex == -1)
                {
                    Log.Error("Query Must contain WHERE");
                    return null;
                }

                int selectStart = selectIndex + "select".Length;

                int selectEnd;

                if (whereIndex != -1)
                    selectEnd = whereIndex;
                else if (orderIndex != -1)
                    selectEnd = orderIndex;
                else
                    selectEnd = input.Length;

                query.SelectPart =
                    input.Substring(selectStart, selectEnd - selectStart).Trim();

                // WHERE        
                if (whereIndex > -1)
                {
                    int whereStart = whereIndex + "where".Length;

                    int whereEnd =
                        orderIndex > -1 ? orderIndex : input.Length;

                    string rawWhere =
                        input.Substring(whereStart, whereEnd - whereStart).Trim();

                    rawWhere = rawWhere.Replace("[", "")
                                       .Replace("]", "")
                                       .Trim();

                    query.WherePart = rawWhere;
                }

                // ORDER BY
                if (orderIndex > -1)
                {
                    int orderStart = orderIndex + "orderby".Length;

                    query.OrderByPart =
                        input.Substring(orderStart).Trim();
                }

                return query;
            }        
        }
    }
}
