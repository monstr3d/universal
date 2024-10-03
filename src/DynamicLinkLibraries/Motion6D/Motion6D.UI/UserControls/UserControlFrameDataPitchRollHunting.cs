using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Motion6D.UI.UserControls
{
    /// <summary>
    /// UserControl of "FrameDataPitchRollHunting" object
    /// </summary>
    public class UserControlFrameDataPitchRollHunting : UserControlFrameData
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlFrameDataPitchRollHunting()
        {
            userControlQuaternion.SetPitchRollHunting();
            List<ComboBox> l = new List<ComboBox>();
            l.AddRange(userControlCoordinates.Boxes);
            l.AddRange(userControlQuaternion.Boxes);
            boxes = l.ToArray();
        }

        #endregion
    }
}
