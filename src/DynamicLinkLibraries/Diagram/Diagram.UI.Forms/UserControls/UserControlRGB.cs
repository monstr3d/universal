using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// User control RGB
    /// </summary>
    public class UserControlRGB : UserControlComboboxListColor
    {
       
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlRGB()
        {
            Count = 3;
            Texts = new string[] { "Red", "Green", "Blue" };
            LabelColors = new Color[] { Color.Red, Color.Green, Color.Blue };
        }
     
    }
}
