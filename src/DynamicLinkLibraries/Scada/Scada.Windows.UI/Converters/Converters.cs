using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Scada.Windows.UI.Converters
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
          /*  foreach (T obj in list)
            {
                IDisplay displayName = obj as IDisplay;
                if (displayName != null)
                {
                    ListPropertyDescriptor<IList, T> descriptor =
                        new ListPropertyDescriptor<IList, T>(displayName.Text, obj);
                    propertyCollection.Add(descriptor);
                }
            }*/

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

    public class ListExpandableConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            /*  if (value is IDisplay)
                  return (((IDisplay)value).Text);*/

            return value;
        }
    }

    class ListNonExpandableConverter : CollectionConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            /*  if (value is IDisplay)
              {
                  return (((IDisplay)value).Text);
              }
              */
            return value;
        }
    }

    class ListPropertyDescriptor<C, T> : PropertyDescriptor where C : IList
    {
        private readonly T _dataObject;

        public ListPropertyDescriptor(string name, T dataObject)
            : base(name, null)
        {
            this._dataObject = dataObject;
        }


        public override bool CanResetValue(object component)
        {
            return (false);
        }

        public override Type ComponentType
        {
            get { return (typeof(C)); }
        }

        public override object GetValue(object component)
        {
            return (this._dataObject);
        }

        public override bool IsReadOnly
        {
            get { return (true); }
        }

        public override Type PropertyType
        {
            get { return (this._dataObject.GetType()); }
        }

        public override void ResetValue(object component)
        {
            // Nothing to do
        }

        public override void SetValue(object component, object value)
        {
            // Nothing to do
        }

        public override bool ShouldSerializeValue(object component)
        {
            return (false);
        }
    }
}