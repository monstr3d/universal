using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{
    public class FilterComposition : IFilter<double>
    {

        IFilter<double> first;

        IFilter<double> second;

        public FilterComposition(IFilter<double> first, IFilter<double> second)
        {
            this.first = first;
            this.second = second;
        }

        double? IFilter<double>.this[double? key] => Calculate(key);

        double? Calculate(double? value) 
        {
            var f = second[value];
            return first[f];
        }
    }
}
