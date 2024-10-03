using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing.Design;

namespace Diagram.UI
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    class StandardAliasEditor : UITypeEditor 
    {

        internal static readonly StandardAliasEditor Singleton = new StandardAliasEditor();

        private StandardAliasEditor()
        {

        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //object o = base.EditValue(context, provider, value);
            //return o;
            PropertyEditors.AliasItem it = value as PropertyEditors.AliasItem;
            return PropertyEditors.AliasTable.EditorInterface.Edit(it);
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
}
