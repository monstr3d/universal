using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;


using Diagram.UI;
using Diagram.UI.Components;
using BasicEngineering.UI.Factory.Forms;

namespace Aviation.UI.Components
{
    public class AviationControlSystemsComponent : DesktopHolder
    {

        public AviationControlSystemsComponent()
            : base(new Editor())
        {
        }

        class Editor : UITypeEditor
        {
            public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                ByteHolder holder = value as ByteHolder;
                BasicEngineering.UI.Factory.Advanced.Forms.FormMain m = StaticExtension.CreateAviationForm(null, holder, null, null, null, null, false, null, null, null, null);
                m.ShowDialog();
                return m.Creator.Holder;
            }

            public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.Modal;
            }
        }

    }
}
