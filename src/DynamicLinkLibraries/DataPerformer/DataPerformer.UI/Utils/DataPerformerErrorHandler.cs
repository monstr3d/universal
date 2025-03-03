using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using Diagram.UI.Utils;

namespace DataPerformer.UI.Utils
{
   /*!!!TEMP /// <summary>
    /// Error handler of data performer
    /// </summary>
  /*  public class DataPerformerErrorHandler : IErrorHandler
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly DataPerformerErrorHandler Object = 
            new DataPerformerErrorHandler();

        #endregion

        #region Ctor

        private DataPerformerErrorHandler()
        {
        }

        #endregion

        #region IErrorHandler Members

        void IErrorHandler.HandleException(Exception e, object o)//int level)
        {
            if (o.GetType().Equals(typeof(int)))
            {
                int level = (int)o;
                if (level == 0)
                {
                    if (e is AssociatedException)
                    {
                        ShowException(e as AssociatedException);
                        return;
                    }
                    Diagram.UI.Utils.ControlUtilites.HandleException(e);
                }
                else
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
                }
                return;
            }
            else
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        void IErrorHandler.ShowMessage(string message, object obj)
        {
            WindowsExtensions.ControlExtensions.ShowMessageBoxModal(message);
        }

        #endregion

        #region Members

        private void ShowException(AssociatedException ao)
        {
            AssociatedAddition aa = ao.Associated;
            INamedComponent nc = aa.AssociatedObject.GetNamedComponent();
            object data = aa.Additional;
            string n = "";
            if (data is string)
            {
                n = data + "";
            }
            else if (data is object[])
            {
                object[] ar = data as object[];
                object al = ar[ar.Length - 1];
                if (al is string)
                {
                    n = al + "";
                }
            }
            n = nc.Name + "." + n;
            Control c = aa.AssociatedObject.GetControl();
            WindowsExtensions.ControlExtensions.ShowMessageBoxModal(c.FindForm(), ao.Exception.Message + " " + n, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion


 
    }*/
}
