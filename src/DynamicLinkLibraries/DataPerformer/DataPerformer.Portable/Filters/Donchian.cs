using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable.Filters
{
    public class Donchian : BasicFilter
    {
        public bool Max
        { get; set; }

   
        public override double? this[double ? a] => Calculate(a);

        double? Calculate(double ? a)
        {
            var c = base[a];
            if (a == null)
            {
                return null;
            }
            if (data.Count > inter.Count)
            {
                data.Dequeue();
            }
            if (data.Count == inter.Count)
            {
                return Max ? data.Max() : data.Min();
            }
            return null;
        }
    }
}
