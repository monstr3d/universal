using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// List of comboboxes with colored labels
    /// </summary>
    public class UserControlComboboxListColor : UserControlComboboxList
    {

        #region Members

        /// <summary>
        /// Color of labels
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color[] LabelColors
        {
            get
            {
                List<Color> c = new List<Color>();
                foreach (UserControlComboboxList uc in list)
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
