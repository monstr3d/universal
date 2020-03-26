using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using Scada.Interfaces;

namespace Scada.Windows.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionWindowsUI
    {
        #region Fields

        private static IScadaInterface scada;

        #endregion

        #region Public Members

        /// <summary>
        /// Scada
        /// </summary>
        public static IScadaInterface Scada
        {
            get { return scada; }
            set { scada = value; }
        }

        /// <summary>
        /// Recursive action of control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="action">The action</param>
        public static void RecursiveAction(this Control control, Action<Control> action)
        {
            action(control);
            foreach (Control c in control.Controls)
            {
               c.RecursiveAction(action);
            }
        }

        /// <summary>
        /// Sets scada interface to control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="scada">The scada</param>
        public static void Set(this Control control, IScadaInterface scada)
        {
            control.SetPrivate(scada);
            scada.OnRefresh += () => { control.SetPrivate(scada); };
            scada.OnStart += () => { control.SetScadaEnabled(true); };
            scada.OnStop += () => { control.SetScadaEnabled(false); };
        }

        /// <summary>
        /// Sets "is enabled" sign to control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="isEnabled">The is enabled sign</param>
        public static void SetScadaEnabled(this Control control, bool isEnabled)
        {
            control.RecursiveAction((Control c) =>
            {
                if (c is IScadaConsumer)
                {
                    (c as IScadaConsumer).IsEnabled = isEnabled;
                }
            });
        }

        #endregion

        #region Private & Internal Members

        private static void SetPrivate(this Control control, IScadaInterface scada)
        {
            control.RecursiveAction((Control c) =>
                {
                    if (c is IScadaConsumer)
                    {
                        (c as IScadaConsumer).Scada = scada;
                    }
                });
        }


        static StaticExtensionWindowsUI()
        {
            string s = Environment.GetEnvironmentVariable("SCADA_DESIGN");
            if (System.IO.File.Exists(s))
            {
                scada = new EmptyScadaInterface(s);
            }
        }

        #endregion
    }
}
