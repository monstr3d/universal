using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{
    public class MultFilter : IFilter<double>
    {
        IFilter<double> filter;

        double coefficient;
        public MultFilter(IFilter<double> filter, double coefficient)
        {
            this.filter = filter;
            this.coefficient = coefficient;
        }

        double? IFilter<double>.this[double ? key] => Calc(key);

        double? Calc(double ? a)
        {
            var c = filter[a];
            return  c == null ? null : coefficient * (double)c;
        }
    }
}
