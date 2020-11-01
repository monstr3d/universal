﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// List of comboboxes with left position of 
    /// colored labels
    /// </summary>
    public class UserControlComboboxListLeftColor : UserControlComboboxListLeft
    {
        #region Members

        /// <summary>
        /// Colors of label
        /// </summary>
        public Color[] LabelColors
        {
            get
            {
                List<Color> c = new List<Color>();
                foreach (UserControlComboboxListLeft uc in list)
                {
                    c.Add(uc.Label.ForeColor);
                }
                return c.ToArray();
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (i >= list.Count)
                    {
                        break;
                    }
                    list[i].Label.ForeColor = value[i];
                }
            }
        }



        #endregion
    }
}
