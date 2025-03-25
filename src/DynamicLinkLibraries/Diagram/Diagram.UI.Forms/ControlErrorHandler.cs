using System.Collections.Generic;
using System.Windows.Forms;

using ErrorHandler;


namespace Diagram.UI
{
    /// <summary>
    /// Error handler of control
    /// </summary>
    public class ControlErrorHandler : IExceptionHandler
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

        void IExceptionHandler.HandleException<T>(T exception, params object[]? obj)
        {
            object o;
            Control c = GetControl(obj, out o);
            if (c != null)
            {
                Utils.ControlUtilites.ShowError(c, exception, resources);
                return;
            }
            StaticExtensionErrorHandler.HandleException(exception, obj);
        }

        void IExceptionHandler.Log(string message, params object[]? obj)
        {
            object o;
            Control c = GetControl(obj, out o);
            if (c != null)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(c.FindForm(), message, ResourceService.Resources.GetControlResource("Error", resources));
                return;
            }
            StaticExtensionErrorHandler.Log(message, obj);
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
