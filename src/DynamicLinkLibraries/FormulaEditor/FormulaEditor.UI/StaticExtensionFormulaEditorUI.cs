using FormulaEditor.Drawing;
using FormulaEditor.Drawing.Symbols;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormulaEditor
{
    /// <summary>
    /// Static extensions
    /// </summary>
    public static class StaticExtensionFormulaEditorUI
    {

        #region Fields

        #endregion

        #region Public Members

        public static Image FromControl(this Control control)
        {
            Image back = new Bitmap(control.Width, control.Height);
            return back;
        }

 
 
        #endregion



        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="exception">Error exception</param>
        static internal void ShowError(this Control control, Exception exception)
        {
            //control.ShowError(exception, FormulaEditor.UI.Utils.ControlUtilites.Resources);
        }

        /// <summary>
        /// Loads resources for control
        /// </summary>
        /// <param name="control"></param>
        static internal void LoadControlResources(this Control control)
        {
            //ResourceService.StaticExtension.LoadControlResources(FormulaEditor.UI.Utils.ControlUtilites.Resources);
        }
    }
}
