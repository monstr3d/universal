using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Simulink.Parser.Library;
using Simulink.Drawing.Library;
using Simulink.Proxy.UI.Interfaces;

namespace Simulink.Proxy.UI.UserControls
{
    /// <summary>
    /// Control which represents Simulink picture
    /// </summary>
    public partial class UserControlSimulinkSystemPicture : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlSimulinkSystemPicture()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Simulink System
        /// </summary>
        public object SimulinkSystem
        {
            set
            {
                if (!(value is SimulinkSubsystem))
                {
                    return;
                }
                SimulinkSubsystem ss = value as SimulinkSubsystem;
                SimulinkDrawing dr = SimulinkDrawing.FromElement(ss.Element);
                Bitmap bmp = dr.Bitmap;
                pictureBox.Width = bmp.Width;
                pictureBox.Height = bmp.Height;
                pictureBox.Image = bmp;
            }
        }

        /// <summary>
        /// The "change system" event handler
        /// </summary>
        public IChangeSystem ChangeSystem
        {
            set
            {
                value.ChangeSystem += delegate(object ss)
                {
                    this.SimulinkSystem = ss;
                };
            }
        }
    }
}
