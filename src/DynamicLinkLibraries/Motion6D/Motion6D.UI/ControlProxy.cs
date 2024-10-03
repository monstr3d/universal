using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Motion6D.Drawing.Interfaces;

namespace Motion6D.UI
{
    class ControlProxy : IControl
    {
        #region Fields

        private Control control;

        #endregion

        #region Ctor

        private ControlProxy(Control control)
        {
            this.control = control;
        }

        #endregion

        #region IControl Members

        int IControl.Width
        {
            get { return control.Width; }
        }

        int IControl.Height
        {
            get { return control.Height; }
        }

        #endregion

        #region Members

        static internal IControl GetProxy(Control control)
        {
            return new ControlProxy(control);
        }

        #endregion
    }
}
