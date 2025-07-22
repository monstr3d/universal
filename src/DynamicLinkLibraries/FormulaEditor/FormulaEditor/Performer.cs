using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor
{
    /// <summary>
    /// Performer of general operations
    /// </summary>
    public class Performer
    {
        /// <summary>
        /// Adding list with shift
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="l">The added list</param>
        /// <param name="shift">The shift</param>
        public void Add(List<string> list, List<string> l, int shift)
        {
            var s = "";
            for (int i = 0; i < shift; i++)
            {
                s += "\t";
            }
            foreach (var item in l)
            {
                list.Add(s + item);
            }
        }
    }
}
