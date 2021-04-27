using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor;
using BaseTypes.Utils;

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">Absciss</param>
        /// <param name="y">Ordinate</param>
        public ParametrizedSeries(Func<Func<object>> x, Func<Func<object>> y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Steps
        /// </summary>
        public virtual void Step()
        {
            AddXY(Converter.ToDouble(x()()), Converter.ToDouble(y()()));

            /*!!! Test of test   (Artificial bug) 
           AddXY(Converter.ToDouble(x()()), Converter.ToDouble(y()()) + 0.0001);

            //End test of test*/

        }

        /// <summary>
        /// Adds point
        /// </summary>
        /// <param name="x">x - coordinate</param>
        /// <param name="y">y - coordinate</param>
        public override void AddXY(double x, double y)
        {
            if (Double.IsNaN(x) | Double.IsNaN(y))
            {
                throw new Exception("NAN");
            }
            base.AddXY(x, y);
        }
    }

}
