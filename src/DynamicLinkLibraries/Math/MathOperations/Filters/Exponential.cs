using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{
    public class Exponential : QueueFilrer
    {
        double coefficient;

        double k;

        int period;

  
        public Exponential(double coefficient, int period) 
        { 
            this.coefficient = coefficient;
            k = 1 - coefficient;
            this.period = period;
        }

        protected override double? Calc(double ? a)
        {
            if (a == null) return null;
            if (queue.Count <= period) 
            { 
                    return a;
            }
            var x = queue.Dequeue();
            return coefficient * a + k * x;
            
        }
    }
}
