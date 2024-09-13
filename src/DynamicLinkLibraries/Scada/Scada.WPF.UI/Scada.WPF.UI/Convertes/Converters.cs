using System.ComponentModel;

using Scada.Interfaces;


namespace Scada.WPF.UI.Convertes
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
        public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
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
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
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

    /// <summary>
    /// Event converter
    /// </summary>
    public class EventConverter : ConverterBase
    {


        // GetStandardValues method requires a string to native type 
        // conversion because the items in the drop-down list are 
        // translated to string.)



        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(StaticExtensionScadaWpfUI.Scada.Events);
        }
    }

    /// <summary>
    /// Converter of real input
    /// </summary>
    public class InputRealConverter : ConverterBase
    {


        // GetStandardValues method requires a string to native type 
        // conversion because the items in the drop-down list are 
        // translated to string.)


        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(StaticExtensionScadaWpfUI.Scada.GetRealList(true));
        }
    }

    /// <summary>
    /// Converter of real output
    /// </summary>
    public class OutputRealConverter : ConverterBase
    {

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(StaticExtensionScadaWpfUI.Scada.GetRealList(false));
        }
    }

    /// <summary>
    /// Converter of real output
    /// </summary>
    public class OutputConverter : ConverterBase
    {

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(StaticExtensionScadaWpfUI.Scada.GetDataList(false));
        }
    }

    /// <summary>
    /// Converter of Bitmap output
    /// </summary>
    public class OutputBooleanConverter : ConverterBase
    {

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(StaticExtensionScadaWpfUI.Scada.GetTypeList(typeof(bool)));
        }
    }

    /// <summary>
    /// Converter of Bitmap output
    /// </summary>
    public class OutputBitmapConverter : ConverterBase
    {

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(StaticExtensionScadaWpfUI.Scada.GetTypeList(typeof(System.Drawing.Bitmap)));
        }
    }


    public class UrlConsumerConverter : ConverterBase
    {
        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return null;// new StandardValuesCollection(StaticExtensionScadaWpfUI.Scada.GetUrlConsumerList());
        }
    }

}