using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable.Filters
{
    public  class BasicFilter : IFilter
    {
        protected IFilter inter;

        public BasicFilter()
        {
            inter = this;
        }

        protected Queue<double> data = new Queue<double>();

        public virtual double this[double a] => Calc(a);

        int IFilter.Count { get; set; }

        void IFilter.Reset()
        {
            data.Clear();
        }

        protected double Calc(double a)
        {
            data.Enqueue(a);
            return a;
        }
    }
}
