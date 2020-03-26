using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diagram.Data.WpfData.Classes
{
    class Disable : IDisposable
    {
        #region Fields

         Dictionary<FrameworkElement, Tuple<Cursor, bool>> data = new Dictionary<FrameworkElement,  Tuple<Cursor, bool>>();

 
        #endregion

        #region Ctor

        internal Disable(FrameworkElement control)
        {
            Action<FrameworkElement> action = (FrameworkElement e) =>
            {
                Tuple<Cursor, bool> t = new Tuple<Cursor,bool>(e.Cursor, e.IsEnabled);
                data[e] = t;
                e.Cursor = Cursors.Wait;
              //  e.IsEnabled = false;
            };
            control.RecursiveAction<FrameworkElement>(action);
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            foreach (FrameworkElement e in data.Keys)
            {
                Tuple<Cursor, bool> t = data[e];
                e.Cursor = t.Item1;
               // e.IsEnabled = t.Item2;
            }
        }

        #endregion
    }
}
