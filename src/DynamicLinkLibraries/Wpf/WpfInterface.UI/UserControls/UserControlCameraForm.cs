using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Markup;

using Diagram.UI.Interfaces;


using WpfInterface.CameraInterface;

using WindowsExtensions;


namespace WpfInterface.UI.UserControls
{
    public partial class UserControlCameraForm : UserControl, IEnabled
    {
        #region Fields

        WpfCamera camera;

        string background;

        #endregion

        #region Ctor


        public UserControlCameraForm()
        {
            InitializeComponent();
        }

        #endregion

        #region IEnabled Members

        bool IEnabled.Enabled
        {
            get
            {
                Control c = this;
                return c.Enabled;
            }
            set
            {
                Control c = this;
                c.Enabled = value;
                if (value)
                {
                    Action<object, Action> act = (object o, Action a) =>
                        {
                            c.InvokeIfNeeded(a);
                        };
                    camera.Set(userControlCamera, this, act);
                    CameraBackground = camera.CameraBackground;
                }
                else
                {
                    userControlCamera.Content = null;
                }
            }
        }

        #endregion


        public System.Windows.Controls.UserControl Control
        {
            get
            {
                return userControlCamera;
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WpfCamera Camera
        {
            get
            {
                return camera;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                camera = value;
                Action<object, Action> act = (object o, Action a) =>
                {
                    userControlCamera.Dispatcher.Invoke(a);
                };
 
                camera.Set(userControlCamera, this, act);
                CameraBackground = camera.CameraBackground;
            }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string CameraBackground
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
                if (value != null)
                {
                    if (value.Length != 0)
                    {
                        System.Windows.Media.Brush br = XamlReader.Parse(value) as System.Windows.Media.Brush;
                        userControlCamera.Background = br;
                    }
                }
            }
        }
    }
}