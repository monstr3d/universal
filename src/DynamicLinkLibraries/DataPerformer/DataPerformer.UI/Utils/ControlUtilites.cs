using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;

using Diagram.UI;
using Diagram.UI.Interfaces;

using ResourceService;
using ErrorHandler;


namespace DataPerformer.UI.Utils
{
    /// <summary>
    /// Control utilites for data performer
    /// </summary>
    public static class ControlUtilites
    {
        #region Fields
        
        static object[] err = new object[2];
        
        #endregion

        /// <summary>
        /// Resources
        /// </summary>
        static public readonly Dictionary<string, object>[] Resources =
            Localizator.CreateResources(new Dictionary<string, object>[][]
            {
                Localizator.CreateResources(new string[] {"rus"}, 
                new ResourceManager[]
                {
                    ResourceControl_Ru.ResourceManager
                }),
                Common.Engineering.Localization.Utils.ControlUtilites.Resources
            }
            );


        static private IExceptionHandler errorHandler;

        internal static void ShowError(System.Windows.Forms.Control c, Exception exception)
        {
            lock (errorHandler)
            {
                err[1] = c;
                StaticExtensionErrorHandler.HandleException(exception, err);
            }
        }

        internal static void ShowMessage(System.Windows.Forms.Control c, string message)
        {
            lock (errorHandler)
            {
                err[1] = c;
                StaticExtensionErrorHandler.Log(message, err);
            }
        }

        static ControlUtilites()
        {
            errorHandler = new ControlErrorHandler(ControlUtilites.Resources);
            err[0] = errorHandler;
        }

    }
}
