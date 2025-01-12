using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable.Filters
{
    public class Average : BasicFilter
    {

        public override double? this[double? a] => Calculate(a);

        double ?Calculate(double? a)
        {
            var c = base[a];
            if (data.Count > inter.Count)
            {
                data.Dequeue();
            }
            if (data.Count == inter.Count)
            {
                return data.Average();
            }
            return null;
        }

    }
}
