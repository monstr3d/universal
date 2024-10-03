using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Interfaces;


namespace Diagram.UI
{
    /// <summary>
    /// Error handler of control
    /// </summary>
    public class ControlErrorHandler : IErrorHandler
    {
        #region Fields

        Dictionary<string, object>[] resources;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resources">Resourcre</param>
        public ControlErrorHandler(Dictionary<string, object>[] resources)
        {
            this.resources = resources;
        }

        #endregion

        #region IErrorHandler Members

        void IErrorHandler.ShowError(Exception exception, object obj)
        {
            object o;
            Control c = GetControl(obj, out o);
            if (c != null)
            {
                Diagram.UI.Utils.ControlUtilites.ShowError(c, exception, resources);
                return;
            }
            Diagram.UI.StaticExtensionDiagramUI.ShowError(exception, obj);
        }

        void IErrorHandler.ShowMessage(string message, object obj)
        {
            object o;
            Control c = GetControl(obj, out o);
            if (c != null)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(c.FindForm(), message, ResourceService.Resources.GetControlResource("Error", resources));
                return;
            }
            Diagram.UI.StaticExtensionDiagramUI.Show(message, obj);
        }

        #endregion


        #region Private

        Control GetControl(object obj, out object o)
        {
            o = obj;
            if (obj is Control)
            {
                return obj as Control;
            }
            if (obj is object[])
            {
                object[] ob = obj as object[];
                o = ob[1];
                return ob[0] as Control;
            }
            return null;
        }

        #endregion

    }
}
