using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable
{
    public class FilterWrapper : DataConsumer, IPostSetArrow, IMeasurements
    {
        protected string kind = "";

        protected string input;


        protected IFilter filter;

        public IFilter Filter { get => filter;  }


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

        IMeasurement measurement;

        IMeasurement measurementOut;

        bool isUpdated = false;

        double outval;

     
        


        public FilterWrapper(string kind) : this(true)
        {
            this.kind = kind;
            SetFilter();
        }

        protected FilterWrapper(bool b) : base(40)
        {
            measurementOut = new FilterMeasurement(this);
        }
        protected void SetFilter()
        {
            filter = kind == "Donchian" ? new Donchian() : new Average();
        }

        public void PostSetArrow()
        {
            Find();
        }

        #region IMeasurements Members

        IMeasurement IMeasurements.this[int number] => measurementOut;

        int IMeasurements.Count => 1;

        bool IMeasurements.IsUpdated { get => isUpdated; set => isUpdated = value; }

        void IMeasurements.UpdateMeasurements()
        {
            var a = measurement.Parameter();
            outval = filter[(double)a];
        }

        #endregion

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

        class IN : IMeasurements
        {
            #region IMeasurements Members

            IMeasurement IMeasurements.this[int number] => throw new NotImplementedException();

            int IMeasurements.Count => throw new NotImplementedException();

            bool IMeasurements.IsUpdated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            void IMeasurements.UpdateMeasurements()
            {
                throw new NotImplementedException();
            }

            #endregion
        }

    }
}
