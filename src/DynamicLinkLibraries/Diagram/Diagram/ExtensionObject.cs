using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI
{
    /// <summary>
    /// Object which contains extension methods
    /// </summary>
    public class ExtensionObject
    {
        /// <summary>
        /// Fills Dictionary from data table
        /// </summary>
        /// <param name="data">The data table</param>
        /// <param name="dic">The dictionary</param>
        public void Fill(DataTable data, Dictionary<string, string> dic)
        {
            dic.Clear();
            foreach (DataRow item in data.Rows)
            {
                var r = item[1]?.ToString();
                if (r != null)
                {
                    if (r.Length > 0)
                    {
                        dic[item[0].ToString()] = r;
                    }
                }
            }
        }

        /// <summary>
        /// Creates data table
        /// </summary>
        /// <param name="strings">Strings</param>
        /// <param name="dic">Dictionary</param>
        public DataTable Create(IEnumerable<string> strings, Dictionary<string, string> dic)
        {
            var dataTable = new DataTable();
            for (int i = 0; i < 2; i++)
            {
                dataTable.Columns.Add();
            }
            Fill(dataTable, strings, dic);
            return dataTable;
        }


        /// <summary>
        /// Fills dictionary from data table
        /// </summary>
        /// <param name="dataTable">The data table</param>
        /// <param name="strings">Strings</param>
        /// <param name="dic">Dictionary</param>
        public void Fill(DataTable dataTable, IEnumerable<string> strings, Dictionary<string, string> dic)
        {
            foreach (var item in strings)
            {
                var s = dic.ContainsKey(item) ? dic[item] : "";
                dataTable.Rows.Add(item, s);
            }
        }
    }
}
