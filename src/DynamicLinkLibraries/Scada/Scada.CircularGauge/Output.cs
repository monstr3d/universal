using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scada.CircularGauge
{
    /// <summary>
    /// Output
    /// </summary>
    public static class Output
    {
        #region Fields

        static public DependencyProperty OutputNameProperty;

        #endregion

        #region Ctor

        static Output()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            OutputNameProperty = DependencyProperty.RegisterAttached("OutputName", typeof(string), typeof(Output));
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets output of element
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Output</returns>
        public static string GetOutputName(this UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            return element.GetValue(Output.OutputNameProperty) as string;
        }


        /// <summary>
        /// Sets output of element
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Output</returns>
        public static void SetOutputName(this UIElement element, string value)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            element.SetValue(Output.OutputNameProperty, value);
        }


        #endregion

    }
}
