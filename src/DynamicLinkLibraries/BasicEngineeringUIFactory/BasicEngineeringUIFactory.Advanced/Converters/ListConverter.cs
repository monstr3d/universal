using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicEngineering.UI.Factory.Advanced.Interfaces;

namespace BasicEngineering.UI.Factory.Advanced.Converters
{
    class ListConverter<T> : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            IList list = value as IList;

            // This isn't a list or has no items
            if ((list == null) || (list.Count == 0))
                return (null);

            // Create New Collection
            List<ListPropertyDescriptor<IList, T>> propertyCollection =
                new List<ListPropertyDescriptor<IList, T>>();

            // Add items to the New Collection
            foreach (T obj in list)
            {
                IDisplay displayName = obj as IDisplay;
                if (displayName != null)
                {
                    ListPropertyDescriptor<IList, T> descriptor =
                        new ListPropertyDescriptor<IList, T>(displayName.Text, obj);
                    propertyCollection.Add(descriptor);
                }
            }

            // Create Collection
            PropertyDescriptorCollection properties =
                new PropertyDescriptorCollection(propertyCollection.ToArray());

            return (properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return (true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string))
                return (string.Empty);

            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
