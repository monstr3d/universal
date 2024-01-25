using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{
    public class AverageFilter : IFilter<double>
    {
        Queue<double> queue = new Queue<double>();  

        public int Count { get; private set; }

        public AverageFilter(int count)
        {
            Count = count;
        }

        double? Process(double ? a)
        {
            if (a == null)
            {  return null; }
            queue.Enqueue((double)a);
            while (queue.Count > Count)
            {
                queue.Dequeue();
            }
            if (queue.Count < Count)
            {
                return null;
            }
            return queue.Average();
        }


        double? IFilter<double>.this[double ? key] => Process(key);
    }
}
