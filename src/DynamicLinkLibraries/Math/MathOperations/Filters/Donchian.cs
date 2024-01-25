using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{
    public class Donchian : IFilter<double>
    {

        internal int period;

        Queue<double> data = new Queue<double>();

        bool max;

        public Donchian(int period, bool max = true)
        {
            this.period = period;
            this.max = max;
        }

        public double? Calc(double? x)
        {
            if (x == null)
            {
                return null;
            }
            double? val = null;
            if (data.Count > 0)
            {
                val = max ? data.Max() : data.Min();
            }
            data.Enqueue((double)x);
            if (data.Count > period)
            {
                data.Dequeue();
            }
            return val;
        }

        double? IFilter<double>.this[double ? key] => Calc(key);
    }
}
