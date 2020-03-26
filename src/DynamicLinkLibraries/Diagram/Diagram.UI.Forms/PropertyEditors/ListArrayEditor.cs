using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.ComponentModel;

using Diagram.UI.Interfaces;
using Diagram.UI;

namespace Diagram.UI.PropertyEditors
{
    /// <summary>
    /// List Editor
    /// </summary>
    public class ListArrayEditor : List<ListArrayItem>, ICustomTypeDescriptor
    {
        #region Fields

        #endregion

        #region Ctor

        internal ListArrayEditor(List<Tuple<string, object>> types, object[] array)
        {
            for (int i = 0;  i < array.Length; i++)
            {
                ListArrayItem it = new ListArrayItem(types[i].Item1, array, i);
                Add(it);
            }
        }


        #endregion

        #region Members



        #endregion

        #region ICustomTypeDescriptor Members

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            string cn = TypeDescriptor.GetClassName(this, true);
            return cn;
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            string cn = TypeDescriptor.GetComponentName(this, true);
            return cn;
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            TypeConverter tc = TypeDescriptor.GetConverter(this, true);
            return tc;
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            EventDescriptor ed = TypeDescriptor.GetDefaultEvent(this, true);
            return ed;
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            object o = TypeDescriptor.GetEditor(this, editorBaseType, true);
            return o;
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            EventDescriptorCollection edc = TypeDescriptor.GetEvents(this, attributes, true);
            return edc;
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            EventDescriptorCollection edc = TypeDescriptor.GetEvents(this, true);
            return edc;
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            ICustomTypeDescriptor d = this;
            return d.GetProperties();
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            PropertyDescriptorCollection coll = new PropertyDescriptorCollection(null);
            for (int i = 0; i < Count; i++)
            {
                coll.Add(new ListArrayDescriptor(this[i]));
   
            }
            return coll;
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion
    }


    /// <summary>
    /// Item of alias table
    /// </summary>
    [TypeConverter(typeof(ListArrayConverter))]
    public class ListArrayItem
    {
        #region Fields

        string name;

        int num;

        object[] array;

        #endregion

        #region Ctor

        internal ListArrayItem(string name, object[] array, int num)
        {
            this.name = name;
            this.array = array;
            this.num = num;
        }

        #endregion

        /// <summary>
        /// Conversion to string
        /// </summary>
        /// <returns>Result of conversion</returns>
        public override string ToString()
        {
            return Value + "";
        }

        #region Properties

        /// <summary>
        /// Name of parameter
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Type
        /// </summary>
        public Type Type
        {
            get {return Value.GetType();}
        }

  
        /// <summary>
        /// Value
        /// </summary>
        public object Value
        {
            get
            {
                return array[num];
            }
            set
            {
                array[num] = value;
            }
        }

        #endregion
    }

    class ListArrayDescriptor : PropertyDescriptor
    {
        ListArrayItem item;
        internal ListArrayDescriptor(ListArrayItem item)
            : base(item.Name, null)
        {
            this.item = item;
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { throw new NotImplementedException(); }
        }

        public override object GetValue(object component)
        {
            return item.Value;
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get
            {
                return item.Type;
            }
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
            item.Value = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
        public override object GetEditor(Type editorBaseType)
        {
            return base.GetEditor(editorBaseType);
        }
    }

    class ListArrayConverter : TypeConverter
    {
        internal static readonly ListArrayConverter Object = new ListArrayConverter();
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

}