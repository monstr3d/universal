using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsExtensions
{
    class Disable : IDisposable
    {
        #region Fields
        Control control;

        bool enabled;
        Cursor cursor;
        #endregion
       
        #region Ctor
        
        internal Disable(Control control)
        {
            cursor = control.Cursor;
            enabled = control.Enabled;
            control.Enabled = false;
            control.Cursor = Cursors.WaitCursor;
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            control.Cursor = cursor;
            control.Enabled = enabled;
        }

        #endregion
    }
}
