using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations.Filters
{

    public class BinaryOperationFilter : IFilter<double>
    {
        private Func<double, double, double> operation;
        private Dictionary<OperationType, Func<double, double, double>> operations =


     new Dictionary<OperationType, Func<double, double, double>>()
     {
         {OperationType.Plus, (a, b) => a + b },
         {OperationType.Minus, (a, b) => a - b },
         {OperationType.Multiply, (a, b) => a * b }
     };

        IFilter<double> first;

        IFilter<double> second;


        public BinaryOperationFilter(OperationType type, IFilter<double> first,
        IFilter<double> second)
        {
            operation = operations[type];
            this.first = first;
            this.second = second;
        }

        double? IFilter<double>.this[double? key] => Calculate(key);

        double? Calculate(double ? a)
        {
            var f = second[a];
            var s = first[f];
            if ((f == null) || (s == null))
            {
                return null;
            }
            return operation((double)f, (double)s);
        }
    }
}

