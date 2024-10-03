using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Drawing;


using Chart.Interfaces;
using Chart.Classes;
using Chart.Drawing.Interfaces;



namespace Chart
{

    /// <summary>
    /// Simple coordinate drawing conmonent
    /// </summary>
    public class SimpleCoordinator : Drawing.Coordinators.SimpleCoordinator
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nx">X - division</param>
        /// <param name="ny">Y - division</param>
        /// <param name="performer">Performer of chart drawing</param>
        public SimpleCoordinator(int nx, int ny)
            : base(nx, ny)
        {
        }


        /// <summary>
        /// Static clean insets
        /// </summary>
        /// <param name="component">Component</param>
        /// <param name="insets">Insets</param>
        public static void ClearInsetsStatic(Control component, int[,] insets)
        {
            if (component == null)
            {
                return;
            }
            Color c = component.BackColor;
            Graphics g = Graphics.FromHwnd(component.Handle);
            Brush brush = new SolidBrush(c);
            g.FillRectangle(brush, 0, 0, insets[0, 0] - 1, component.Height);
            g.FillRectangle(brush, 0, component.Height - insets[1, 1] + 1, component.Width,
                insets[1, 1] - 1);
        }


        /// <summary>
        /// Clears insets
        /// </summary>
        /// <param name="component">Chart component</param>
        /// <param name="insets">Insets</param>
        public void ClearInsets(Control component, int[,] insets)
        {
            ClearInsetsStatic(component, insets);
        }


  
    }
}
