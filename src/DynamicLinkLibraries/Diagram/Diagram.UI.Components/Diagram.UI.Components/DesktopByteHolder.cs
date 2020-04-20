using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.IO;

namespace Diagram.UI.Components
{
    /// <summary>
    /// Holder of desktop
    /// </summary>
    public partial class DesktopByteHolder : Component, ICustomTypeDescriptor

    {
        #region Fields

        /// <summary>
        /// Desktop
        /// </summary>
        protected PureDesktopPeer desktop = null;

        /// <summary>
        /// Editor
        /// </summary>
        protected UITypeEditor editor;

        /// <summary>
        /// Content
        /// </summary>
        protected byte[] content = new byte[0];

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DesktopByteHolder()
        {
            InitializeComponent();
            editor = new StandardEditor(this);
        }

        /// <summary>
        /// Constructor with editor
        /// </summary>
        /// <param name="editor">The editor</param>
        protected DesktopByteHolder(UITypeEditor editor)
            : this()
        {
            this.editor = editor;
        }

        #endregion


        #region Members


        /// <summary>
        /// Content
        /// </summary>
        [Browsable(false)]
        [ReadOnly(false)]
        [Description("Control")]
        [TypeConverter(typeof(DesignerConverter))]
        public byte[] Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        /// <summary>
        /// Desktop
        /// </summary>
        [Browsable(false)]
        public virtual PureDesktopPeer Desktop
        {
            get
            {
                if (desktop == null)
                {
                    if (content.Length > 0)
                    {
                        desktop = new PureDesktopPeer();
                        desktop.Load(content);
                    }
                }
                return desktop;
            }
        }

        object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.OpenRead(openFileDialog.FileName);
                content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);
            }
            return content;
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
            PropertyDescriptorCollection c = TypeDescriptor.GetProperties(this, true);
            List<PropertyDescriptor> l = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor pd in c)
            {
                if (pd.Name.Equals("Content"))
                {
                    continue;
                }
                l.Add(pd);
            }
            l.Add(new ContentProprertyDescriptor(this));
            return new PropertyDescriptorCollection(l.ToArray());
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion


        class ContentProprertyDescriptor : PropertyDescriptor
        {
            DesktopByteHolder holder;

            internal ContentProprertyDescriptor(DesktopByteHolder holder) :
                base("Content", null)
            {
                this.holder = holder;
            }


            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override Type ComponentType
            {
                get { return typeof(Component); }
            }

            public override object GetValue(object component)
            {
                return holder.content;
            }

            public override bool IsReadOnly
            {
                get { return false; }
            }

            public override Type PropertyType
            {
                get { return typeof(byte[]); }
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
                holder.content = value as byte[];
            }

            public override bool ShouldSerializeValue(object component)
            {
                return true;
            }

            public override object GetEditor(Type editorBaseType)
            {
                return holder.editor;
            }
        }

        class StandardEditor : UITypeEditor
        {
            private DesktopByteHolder holder;

            internal StandardEditor(DesktopByteHolder holder)
            {
                this.holder = holder;
            }

            public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                return holder.EditValue(context, provider, value);
            }

            public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.Modal;
            }
        }

        class DesignerConverter : TypeConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

        }
    }
}
