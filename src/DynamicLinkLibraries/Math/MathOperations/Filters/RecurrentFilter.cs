using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{
    public class RecurrentFilrer : IFilter<Double>
    {
        double[] coefficients;

        int i = 0;
        double sum = 0;

        Queue<double> queue = new Queue<double>();

        public RecurrentFilrer(double[] coefficients, bool astatic = true)
        {
            if (astatic)
            {
                double a = 0;
                LinkedList<double> list = new LinkedList<double>();
                foreach (double d in coefficients)
                {
                    a += d;
                    list.AddLast(d);
                }
                list.AddLast(a);
                this.coefficients = list.ToArray();
                return;
            }
            this.coefficients = coefficients.Clone() as double[];
        }

        public double? this[double ? x]
        {
            get
            {
                if (x == null)
                {
                    return null;
                }
                queue.Enqueue((double)x);
                if (queue.Count < coefficients.Length)
                {
                    return null;
                }
                if (queue.Count > coefficients.Length)
                {
                    queue.Dequeue();
                }
                sum = 0;
                int i = 0;
                foreach (var a in queue)
                {
                    sum += a * coefficients[i];
                    ++i;
                }
                return sum;
            }
        }


    }
}
