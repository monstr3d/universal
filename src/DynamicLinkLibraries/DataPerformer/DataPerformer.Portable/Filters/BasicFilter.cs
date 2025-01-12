using System.Collections.Generic;

namespace DataPerformer.Portable.Filters
{
    /// <summary>
    /// Basic filter
    /// </summary>
    public  class BasicFilter : IFilter
    {
        protected IFilter inter;

        int count = 2;

        public BasicFilter()
        {
            inter = this;
        }

        protected Queue<double> data = new Queue<double>();

        public virtual double? this[double ?a] => Calc(a);

        int IFilter.Count
        {
            get => count; 
            set { data.Clear(); count = value; }
        }

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
