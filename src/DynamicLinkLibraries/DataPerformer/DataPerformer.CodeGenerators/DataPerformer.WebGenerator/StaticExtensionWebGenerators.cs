using AssemblyService.Attributes;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WindowsExtensions;

namespace DataPerformer.WebGenerator
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionWebGenerators
    {
        static StaticExtensionWebGenerators()
        {
            new Generator();
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static internal void Fill(this DataGridView dataGridView, IEnumerable<string> strings, Dictionary<string, string> dic)
        {
            foreach (var item in strings)
            {
                var s = dic.ContainsKey(item) ? dic[item] : "";
                dataGridView.Rows.Add(item, s); 
            }
        }

        static internal void Fill(this DataTable data, Dictionary<string, string> dic)
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

        static internal void Fill(this Control c, Dictionary<string, string> dic)
        {
            c.ToDataTable().Fill(dic);
        }

    }
}
