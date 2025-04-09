using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Diagram.UI.PropretyGridHelpers
{
    /// <summary>
    /// Table of double dictionary
    /// </summary>
    public class DictionaryTable<T> : List<DictionaryItem<T>>, ICustomTypeDescriptor
    {
        /// <summary>
        /// Sets dictionary to property grid
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="grid">Grid</param>
        static public void Set(IDictionary<string, T> dictionary, PropertyGrid grid)
        {
            grid.SelectedObject = new DictionaryTable<T>(dictionary);
        }

        private DictionaryTable(IDictionary<string, T> dictionary)
        {
            List<string> l = new List<string>();
            l.AddRange(dictionary.Keys);
            l.Sort();
            foreach (string key in dictionary.Keys)
            {
                Add(new DictionaryItem<T>(key, dictionary));
            }
        }



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
                coll.Add(new DictionaryItemDescriptor<T>(this[i]));
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
    /// Item of double dictionary table
    /// </summary>
    //[TypeConverter(typeof(DictionaryConverter))]
    public class DictionaryItem<T>
    {
        #region Fields

        string name;

        IDictionary<string, T> dictionary;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="dictionary">Dictionary of items</param>
        internal DictionaryItem(string name, IDictionary<string, T> dictionary)
        {
            this.name = name;
            this.dictionary = dictionary;
        }

        #endregion


        #region Members

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Value
        /// </summary>
        public T Value
        {
            get
            {
                return dictionary[name];
            }
            set
            {
                dictionary[name] = value;
            }
        }

        internal Type Type
        {
            get
            {
                return typeof(T);
            }
        }

        #endregion

    }


    class DictionaryItemDescriptor<T> : PropertyDescriptor
    {
        DictionaryItem<T> item;

        internal DictionaryItemDescriptor(DictionaryItem<T> item)
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
            get { throw new ErrorHandler.OwnException("The method or operation is not implemented."); }
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
                return typeof(T);
            }
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }


        public override void SetValue(object component, object value)
        {
            item.Value = (T)value;
        }
    }
}