using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Scada.Interfaces;

namespace Celestrak.NORAD.Satellites.Wpf.UI.Converters
{
    /// <summary>
    /// Base converter
    /// </summary>
    public class ConverterBase : TypeConverter
    {
        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Exclusive</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Supported</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="sourceType">Source type</param>
        /// <returns>@Can convert" sign</returns>
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

        // If the type of the value to convert is string, parses the string 
        // and returns the integer to set the value of the property to. 
        // This example first extends the integer array that supplies the 
        // standard values collection if the user-entered value is not 
        // already in the array.

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Contecxt</param>
        /// <param name="culture">Culture</param>
        /// <param name="value">Value</param>
        /// <returns>Return value</returns>
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                return value;
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
    }

    public class SatelliteDataConverter : ConverterBase
    {
        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            XElement document = StaticExtensionCelestrakNORADSatellitesWpfUI.ScadaDesign.XmlDocument;
            return new StandardValuesCollection(
                document.GetItems(StaticExtensionCelestrakNORADSatellitesWpfUI.CelestrakNORADSatellitesSatelliteData));
        }
    }
}
