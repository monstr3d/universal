using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Event.Interfaces;
using DataPerformer.Interfaces;
using WindowsExtensions;
using DataPerformer.Interfaces.Attributes;

namespace WebCamCapture.UI.UserControls
{ 

    [CalculationReasons(new string[] { StaticExtensionEventInterfaces.Realtime, StaticExtensionEventInterfaces.RealtimeLogAnalysis })]
    public partial class UserControlCamera : UserControl, IPreparation, IRealTimeStartStop, 
        IRuntimeUpdate, IUpdatableObject
    {

        #region Fields

        SuperWebCamMeasurements camera;

        Point point = new Point(0, 0);

        Bitmap bitmap;

        volatile Bitmap bmp;

        #endregion

        public UserControlCamera()
        {
            InitializeComponent();
        }

        event Action IRealTimeStartStop.OnStart
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action IRealTimeStartStop.OnStop
        {
            add
            {

            }

            remove
            { 

            }
        }

        void IRealTimeStartStop.Start()
        {
            panelBox.Visible = false;
            panelPicture.Visible = true;
        }

        void IRealTimeStartStop.Stop()
        {
            panelBox.Visible = true;
            panelPicture.Visible = false;
        }


        #region Internal Members

        internal SuperWebCamMeasurements Camera
        {
            set
            {
                camera = value;
                textBoxHeight.Text = camera.Height + "";
                textBoxWidth.Text = camera.Width + "";
            }
        }


        #endregion

        bool IRuntimeUpdate.ShouldRuntimeUpdate
        {
            get
            {
                return true;
            }

            set
            {
            }
        }

        Action IUpdatableObject.Update
        {
            get
            {
                return UpdateUI;
            }
        }

        bool IUpdatableObject.ShouldUpdate
        {
            get
            {
                return true;
            }

            set
            {
               
            }
        }

        void IPreparation.Prepare()
        {
            try
            {
                camera.Width = int.Parse(textBoxWidth.Text);
                camera.Height = int.Parse(textBoxHeight.Text);
             }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        void UpdateUI()
        {
            Bitmap o = camera.Bitmap;
            if (bitmap == o)
            {
                return;
            }
            bitmap = o;
            bmp = new Bitmap(bitmap);
            this.InvokeIfNeeded(() => 
                {
                    panelPicture.Refresh();
                });
        }

        private void panelPicture_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (bmp != null)
                {
                    e.Graphics.DrawImage(bmp, point);
                }
            }
            catch
            {

            }
        }
    }

}
