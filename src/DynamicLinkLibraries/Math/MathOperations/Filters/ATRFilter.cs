using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{
    public class ATRFilter : IFilter<double>
    {
        int n;
        double val;
        int i = 0;
        public ATRFilter(int n) 
        { 
            this.n = n;
        }

        double? Calculate(double? a)
        {
            if (a == null)
            {
                return null;
            }
            ++i;
            var c = (double)a;
            if (i > n)
            {
                val += c /n;
                return null;
            }
            val = val / (n - 1) + c / n;
            return val;
        }

        double? IFilter<double>.this[double? key] => Calculate(key);
    }
}
