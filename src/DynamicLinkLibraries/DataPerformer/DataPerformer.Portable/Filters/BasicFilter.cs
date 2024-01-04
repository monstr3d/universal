using System.Collections.Generic;

namespace DataPerformer.Portable.Filters
{
    /// <summary>
    /// Basic filter
    /// </summary>
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
