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
    /// Table of alias
    /// </summary>
    public class AliasTable : List<AliasItem>, ICustomTypeDescriptor
    {
        #region Fields

        bool realOnly = false;

        static IAliasEditorInteface editorInterface = StandardAliasEditorInterface.Singleton;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="a">Alias</param>
        /// <param name="realOnly">"Read only" sign</param>
       internal AliasTable(IAlias a, bool realOnly)
       {
            this.realOnly = realOnly;
            IList<string> names = a.AliasNames;
            foreach (string n in names)
            {
                AliasItem it = new AliasItem(a, n);
                Add(it);
            }
        }


        #endregion

        #region Members


        /// <summary>
        /// Global editor interface
        /// </summary>
        static public IAliasEditorInteface EditorInterface
        {
            get
            {
                return editorInterface;
            }
            set
            {
                editorInterface = value;
            }
        }

        /// <summary>
        /// Gets dictionary from alias
        /// </summary>
        /// <param name="alias">The alias</param>
        /// <returns>The dictionary</returns>
        static public Dictionary<string, object> GetDictionary(IAlias alias)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            IList<string> n = alias.AliasNames;
            foreach (string name in n)
            {
                d[name] = alias[name];
            }
            return d;
        }

        /// <summary>
        /// Adds alias to dictionary
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="dictionary">Dictionary</param>
        static public void AddDicitionary(IAlias alias, Dictionary<string, object>
            dictionary)
        {
            IList<string> n = alias.AliasNames;
            foreach (string name in n)
            {
                dictionary[name] = alias[name];
            }
        }

        /// <summary>
        /// Sets dictionary to alias
        /// </summary>
        /// <param name="d">Dictionary</param>
        /// <param name="alias">Alias</param>
        static public void SetDictionary(Dictionary<string, object> d, IAlias alias)
        {
            IList<string> names = alias.AliasNames;
            foreach (string name in names)
            {
                if (d.ContainsKey(name))
                {
                    alias[name] = d[name];
                }
            }
        }

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
                coll.Add(new AliasItemDescriptor(this[i], true));
                if (realOnly)
                {
                    continue;
                }
                coll.Add(new AliasItemDescriptor(this[i], false));
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
    [TypeConverter(typeof(AliasTableConverter))]
    public class AliasItem
    {
        #region Fields
        
        IAlias alias;

        string name;

        #endregion

        #region Ctor
 
        internal AliasItem(IAlias alias, string name)
        {
            this.name = name;
            this.alias = alias;
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
        /// Alias
        /// </summary>
        public IAlias Alias
        {
            get
            {
                return alias;
            }
        }

        /// <summary>
        /// Value
        /// </summary>
        public object Value
        {
            get
            {
                return alias[name];
            }
            set
            {
                alias[name] = value;
            }
        }

        /// <summary>
        /// Properties
        /// </summary>
        [TypeConverter(typeof(AliasTableConverter))]
        public object[] Properties
        {
            get
            {
                return new object[] { alias, name, alias[name] };
            }
            set
            {
                object[] o = value as object[];
                alias[name] = o[2];
            }
        }

        /// <summary>
        /// Real value
        /// </summary>
        [TypeConverter(typeof(AliasTableConverter))]
        public double? Real
        {
            get
            {
                Double a = 0;
                if (!alias.GetType(name).Equals(a))
                {
                    return null;
                }
                return (double)alias[name];
            }
            set
            {
                alias[name] = value;
            }
        }

        #endregion

        
    }

    class AliasItemDescriptor : PropertyDescriptor
    {
        AliasItem item;

        bool isDouble;

        internal AliasItemDescriptor(AliasItem item, bool isDouble)
           : base(item.Name + ((isDouble) ? " (real)": ""), null)
        {
            this.item = item;
            this.isDouble = isDouble;
             
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { throw new ErrorHandler.WriteProhibitedException(); }
        }

        public override object GetValue(object component)
        {
            if (isDouble)
            {
                return item.Real;
            }
            return item;
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get 
            {
                if (isDouble)
                {
                    return typeof(double?);
                }
                Type type = item.GetType();
                return type;
            }
        }

        public override void ResetValue(object component)
        {

        }

        public override void SetValue(object component, object value)
        {
            if (isDouble)
            {
                item.Value = value;
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override object GetEditor(Type editorBaseType)
        {
            if (isDouble)
            {
                return base.GetEditor(editorBaseType);
            }
            return StandardAliasEditor.Singleton;
        }

    }


    class AliasTableConverter : TypeConverter
    {
        internal static readonly AliasTableConverter Object = new AliasTableConverter();

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) & value is AliasItem)
            {
                AliasItem it = value as AliasItem;
                return AliasTable.EditorInterface.GetText(it.Alias, it.Name);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    /// <summary>
    /// Intreface for editing of object
    /// </summary>
    public interface IAliasEditorInteface
    {
        /// <summary>
        /// Edits item
        /// </summary>
        /// <param name="item">The item to edit</param>
        /// <returns>Result item</returns>
        AliasItem Edit(AliasItem item);

        /// <summary>
        /// Gets text of alias item
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="name">Item name</param>
        /// <returns>Text</returns>
        string GetText(IAlias alias, string name);

    }

    /// <summary>
    /// Inteface for alias edition
    /// </summary>
    public class StandardAliasEditorInterface : IAliasEditorInteface
    {

        internal static readonly StandardAliasEditorInterface Singleton = new StandardAliasEditorInterface();

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        protected StandardAliasEditorInterface()
        {

        }

        #endregion

        #region IAliasEditorInteface Members

        AliasItem IAliasEditorInteface.Edit(AliasItem item)
        {
            FormStandardAliasEditor form = new FormStandardAliasEditor(item);
            form.ShowDialog();
            return item;
        }

        /// <summary>
        /// Gets text by alias and name
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="name">Name</param>
        /// <returns>Corresponding text</returns>
        public virtual string GetText(IAlias alias, string name)
        {
            object o = alias[name];
            Type type = o.GetType();
            if (type.IsArray)
            {
                string fn = type.FullName;
                string s = "";
                if (fn.Contains("Boolean"))
                {
                    s = "Bool";
                }
                else if (fn.Contains("Double"))
                {
                    s = "Double";
                }
                else if (fn.Contains("Int32"))
                {
                    s = "Int32";
                }
                else if (fn.Contains("Single"))
                {
                    s = "Single";
                }
                Array arr = o as Array;
                s += "[";
                if (arr.Rank == 1)
                {
                    s += arr.Length + "]";
                }
                if (arr.Rank == 2)
                {
                    s += arr.GetLength(0) + ", " + arr.GetLength(1) + "]";
                }
                return s;  
            }
            return alias[name] + "";
        }

        #endregion
    }

}