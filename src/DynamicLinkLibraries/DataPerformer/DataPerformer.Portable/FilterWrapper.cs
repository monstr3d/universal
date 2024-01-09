using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Filters;
using Diagram.Interfaces;
using System;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Wrapper of filters
    /// </summary>
    public class FilterWrapper : DataConsumer, IPostSetArrow, IMeasurements, IRunning
    {

        #region Fields 

        protected int  kind = 0;

        protected string input;

        protected IFilter filter;

        IMeasurement measurement;

        IMeasurement measurementOut;

        bool isUpdated = false;

        double? outval;

        bool isRunning = false;

        Action<IRunning, bool> running;

        #endregion

        #region Ctor

        public FilterWrapper(int kind) : this(true)
        {
            this.kind = kind;
            SetFilter();
        }

        protected FilterWrapper(bool b) : base(40)
        {
        }

        #endregion

        #region Members

        Donchian Donchian
        {
            get =>
               filter is Donchian ? filter as Donchian : new Donchian();
        }
        protected void SetFilter()
        {
            switch (kind)
            {
                case 0:
                    if (!(filter is Average))
                    {
                        filter = new Average();
                    }
                    break;
                case 1:
                    var d = Donchian;
                    d.Max = true;
                    filter = d;
                    break;
                case 2:
                    d = Donchian;
                    d.Max = false;
                    filter = d;
                    break;
                default: throw new ArgumentException();
            }

            measurementOut = new FilterMeasurement(this);
        }



        public IFilter Filter { get => filter; }


        public string Input

        { get => input; set { input = value; Find(); } }

        protected void Find()
        {
            try
            {
                measurement = this.FindMeasurement(input);
            }
            catch { }
        }

        public int Kind 
        { 
            get => kind; 
            set 
            { 
               kind = value; 
               SetFilter(); 
            }
        
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Find();
        }

        #endregion

        #region IMeasurements Members

        IMeasurement IMeasurements.this[int number] => measurementOut;

        int IMeasurements.Count => 1;

        bool IMeasurements.IsUpdated
        {
            get => isUpdated;
            set => isUpdated = value;
        }

        void IMeasurements.UpdateMeasurements()
        {
            var a = (double?)measurement.Parameter();
            outval = filter[a];
        }

        #endregion

        #region IStarted Members

        bool IRunning.IsRunning
        {
            get => isRunning;
            set
            {
                isRunning = value;
                if (value) filter.Reset();
                running?.Invoke(this, value);
            }
        }

        event Action<IRunning, bool> IRunning.Running
        {
            add
            {
                running += value;
            }

            remove
            {
                running -= value;
            }
        }



    #endregion

    #region Measurement class


    class FilterMeasurement : IMeasurement, IAssociatedObject
        {
            public FilterMeasurement(FilterWrapper filter)
            {
                this.filter = filter;
            }


            FilterWrapper filter;

            object func() => filter.outval;

            Func<object> IMeasurement.Parameter => func;

            string IMeasurement.Name => "Output";

            object IMeasurement.Type => (double)0;

            object IAssociatedObject.Object { get => filter; set  { } }
        }

        #endregion
    }
}
