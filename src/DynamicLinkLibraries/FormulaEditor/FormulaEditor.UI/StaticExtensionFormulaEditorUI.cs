using System;
using System.Collections.Generic;
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
