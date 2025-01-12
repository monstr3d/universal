using System.Linq;

namespace DataPerformer.Portable.Filters
{
    /// <summary>
    /// Donchian filter
    /// </summary>
    public class Donchian : BasicFilter
    {
        public bool Max
        { get; set; }

   
        public override double? this[double ? a] => Calculate(a);

        double? Calculate(double ? a)
        {
            double? ret = null;
            if (data.Count == inter.Count)
            {
                ret = Max ? data.Max() : data.Min();
            }
            var c = base[a];
            if (a == null)
            {
                return null;
            }
            while (data.Count > inter.Count)
            {
                data.Dequeue();
            }
            return ret;
        }
    }
}
