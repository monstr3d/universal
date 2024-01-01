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

        public virtual double? this[double ?a] => Calc(a);

        int IFilter.Count { get; set; } = 2;

        void IFilter.Reset()
        {
            data.Clear();
        }

        protected double? Calc(double ? a)
        {
            if (a != null)
            {
                data.Enqueue((double)a);
            }
            return a;
        }
    }
}
