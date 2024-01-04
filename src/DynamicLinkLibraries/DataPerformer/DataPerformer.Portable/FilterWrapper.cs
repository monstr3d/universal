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

        protected string kind = "";

        protected string input;

        protected IFilter filter;

        IMeasurement measurement;

        IMeasurement measurementOut;

        bool isUpdated = false;

        double? outval;

        bool isRunning = false;


        #endregion

        #region Ctor

        public FilterWrapper(string kind) : this(true)
        {
            this.kind = kind;
            SetFilter();
        }

        protected FilterWrapper(bool b) : base(40)
        {
        }

        #endregion

        #region Members

        protected void SetFilter()
        {
            bool b = kind == "Donchian";
            if (b)
            {
                filter = new Donchian();
                measurementOut = new DonchianMeasurement(this);
            }
            else
            {
                filter = new Average();
                measurementOut = new FilterMeasurement(this);
            }
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

        public string Kind { get => kind; }

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
            }
        }


        #endregion

        #region Measurement class

        class DonchianMeasurement : FilterMeasurement
        {
            public DonchianMeasurement(FilterWrapper filter) : base(filter) { }
        }

        class FilterMeasurement : IMeasurement
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
        }

        #endregion
    }
}
