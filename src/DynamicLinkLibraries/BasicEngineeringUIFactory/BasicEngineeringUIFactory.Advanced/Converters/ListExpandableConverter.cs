using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BasicEngineering.UI.Factory.Advanced.Interfaces;

namespace BasicEngineering.UI.Factory.Advanced.Converters
{
    public class ListExpandableConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            if (value is IDisplay)
            {
                return (((IDisplay)value).Text);
            }
            return (string.Empty);
        }
    }
}
