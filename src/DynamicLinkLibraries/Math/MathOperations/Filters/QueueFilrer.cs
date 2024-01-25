using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{
    public abstract class QueueFilrer : IFilter<double>
    {

        protected Queue<double> queue = new Queue<double>();

        protected abstract double? Calc(double? a);

        double? Calculate(double? value)
        {
            if (value == null)
            {  return null; }
            queue.Enqueue((double)value);
            return Calc(value);
        }

        public double? this[double? key] => Calculate(key);
    }
}
