using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor;
using BaseTypes.Utils;
using BaseTypes;

namespace DataPerformer.SeriesTypes
{
    /// <summary>
    /// The parametrized series
    /// </summary>
    public class ParametrizedSeries : Series
    {
        /// <summary>
        /// Absciss
        /// </summary>
        new protected Func<Func<object>> x;

        /// <summary>
        /// Ordinate
        /// </summary>
        new protected Func<Func<object>> y;

        protected object ordinateType;

        protected Action step;

        readonly static double a = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">Absciss</param>
        /// <param name="y">Ordinate</param>
        /// <param name="ordinateType">Ordinate type</param>
        public ParametrizedSeries(Func<Func<object>> x, 
            Func<Func<object>> y, object ordinateType = null) 
        {
            this.x = x;
            this.y = y;
            this.ordinateType = ordinateType;
            if (ordinateType == null)
            {
                step = StandardStep;
            }
            else if (ordinateType.Equals(a))
            {
                step = StandardStep;
            }
            else if (ordinateType is ArrayReturnType)
            {
                var t = ((ArrayReturnType)ordinateType).IsObjectType;
                step = t ? ArrayObjectStep: ArrayStep;
            }
        }

        /// <summary>
        /// Attached object
        /// </summary>
        public object Attached
        { get; set; }

        /// <summary>
        /// Steps
        /// </summary>
        public virtual void Step()
        {
            step();
        }

        private void StandardStep()
        {
            var xx = x();
            var a = xx();
            var yy = y();
            var b = yy();
            AddXY(Converter.ToNullDouble(a), Converter.ToNullDouble(b));

            /*!!! Test of test   (Artificial bug) 
           AddXY(Converter.ToDouble(x()()), Converter.ToDouble(y()()) + 0.0001);

            //End test of test*/

        }

        private void ArrayObjectStep()
        {
            var a = x()();
            var b = y()();
            if (a == null | b == null)
            {
                return;
            }
            object[] array = b as object[];
            var xx = new double[array.Length];
            Array.Copy(array, xx, xx.Length);
            AddXY((double)a, xx);
        }



        private void ArrayStep()
        {
            var a = x()();
            var b = y()();
            if (a == null | b == null)
            {
                return;
            }
            AddXY((double)a, b as double[]);
        }


        /// <summary>
        /// Adds point
        /// </summary>
        /// <param name="x">x - coordinate</param>
        /// <param name="y">y - coordinate</param>
        public override void AddXY(double x, double y)
        {
            if (double.IsNaN(x) | double.IsNaN(y))
            {
                throw new ErrorHandler.OwnException("NAN");
            }
            base.AddXY(x, y);
        }
    }

}
