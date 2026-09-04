using System.Linq;

namespace DataPerformer.Portable.Filters
{
    public class Average : BasicFilter
    {

        public override double? this[double? a] => Calculate(a);

        double ?Calculate(double? a)
        {
            var c = base[a];
            if (c == null)
            {
                return null;
            }
            if (data.Count > inter.Count)
            {
                data.Dequeue();
            }
            if (data.Count >= inter.Count)
            {
                return data.Average();
            }
            return null;
        }

    }
}
