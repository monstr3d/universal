﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using AssemblyService.Attributes;
using Diagram.UI;
using Diagram.UI.Utils;

namespace Motion6D.UI
{
    /// <summary>
    /// Extension of methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionMotion6DUI
    {
        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="exception">Error exception</param>
        static internal void ShowError(this Control control, Exception exception)
        {
            control.ShowError(exception, Utils.ControlUtilites.Resources);
        }

        /// <summary>
        /// Loads resources for control
        /// </summary>
        /// <param name="control"></param>
        static public void LoadControlResources(this Control control)
        {
            control.LoadControlResources(Utils.ControlUtilites.Resources);
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        static StaticExtensionMotion6DUI()
        {
            new Binder();
        }


        class Binder : SerializationBinder
        {
            internal Binder()
            {
                this.Add();
            }


            public override Type BindToType(string assemblyName, string typeName)
            {
                string ass = assemblyName;
                string tn = typeName;
                if (assemblyName.Contains("MotionUI"))
                {
                    ass = typeof(Motion6D.UI.IPositionCollectionMeasureChooser).Assembly.FullName;
                    tn = tn.Replace("MotionUI", "Motion6D.UI");
                }
                Type t = Type.GetType(String.Format("{0}, {1}", tn, ass));
                return t;
            }
        }
    }
}
