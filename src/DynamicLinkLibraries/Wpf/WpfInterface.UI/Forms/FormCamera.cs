using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI;

using DataPerformer.UI;

using Motion6D.UI;

using WindowsExtensions;

using WpfInterface.CameraInterface;



namespace WpfInterface.UI.Forms
{
    public partial class FormCamera : Form, IUpdatableForm, IRedraw, IStartStop
    {
        #region Fields

        WpfCamera camera;

        IObjectLabel label;

        private ToolStripButton[][] startStopPauseButtons;

        bool isPaused = false;

        Diagram.UI.Interfaces.ActionType actionType = ActionType.Stop;


        #endregion

        #region Ctor

        public FormCamera()
        {
            InitializeComponent();
            startStopPauseButtons = 
                new ToolStripButton[][] 
                { toolStripStart.ToSingleArray<ToolStripButton>(), 
                    toolStripStop.ToSingleArray<ToolStripButton>(), 
                    toolStripButtonPause.ToSingleArray<ToolStripButton>() };
 
        }

        internal FormCamera(IObjectLabel label, WpfCamera camera)
            : this()
        {
            this.LoadControlResources();
            this.label = label;
            UpdateFormUI();
            this.camera = camera;
            toolStripTextBoxFieldOfView.Text = camera.FieldOfView + "";
            toolStripTextBoxNearPlaneDistance.Text = camera.NearPlaneDistance + "";
            toolStripTextBoxFarPlaneDistance.Text = camera.FarPlaneDistance + "";
            toolStripTextBoxScale.Text = camera.Scale + "";
            Motion6D.Interfaces.ILinear6DForecast forecast = camera;
            toolStripTextBoxCoordinateError.Text = forecast.CoordinateError + "";
            toolStripTextBoxAngleError.Text = (forecast.AngleError * 180 / Math.PI) + "";
            toolStripTextBoxForecatTime.Text = forecast.ForecastTime.TotalSeconds + "";
            Action<object, Action> act = (object o, Action a) =>
            {
                userControlCameraForm.InvokeIfNeeded(a);
            };
            camera.Set(userControlCameraForm.Control, userControlCameraForm, act);
            userControlCameraForm.CameraBackground = camera.CameraBackground;
        }

        #endregion

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        #region IRedraw Members

        void IRedraw.Redraw()
        {
            this.InvokeIfNeeded(camera.UpdateImage);
        }

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, Diagram.UI.Interfaces.ActionType actionType)
        {
            this.actionType = actionType;
            this.InvokeIfNeeded<object, Diagram.UI.Interfaces.ActionType>(Act, type, actionType);
        }

        #endregion
  
        #region Private Members

        private void Accept()
        {
            try
            {
                camera.FieldOfView = Double.Parse(toolStripTextBoxFieldOfView.Text);
                camera.NearPlaneDistance = Double.Parse(toolStripTextBoxNearPlaneDistance.Text);
                camera.FarPlaneDistance = Double.Parse(toolStripTextBoxFarPlaneDistance.Text);
                camera.Scale = Double.Parse(toolStripTextBoxScale.Text);
                Motion6D.Interfaces.ILinear6DForecast forecast = camera;
                forecast.CoordinateError = Double.Parse(toolStripTextBoxCoordinateError.Text);
                forecast.AngleError = Double.Parse(toolStripTextBoxAngleError.Text) * Math.PI / 180;
                forecast.ForecastTime = TimeSpan.FromSeconds(Double.Parse(toolStripTextBoxForecatTime.Text));
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        void LoadBrush()
        {
            if (openFileDialogFigure.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            try
            {
                StreamReader reader = new StreamReader(openFileDialogFigure.FileName);
                string s = "";
                while (true)
                {
                    string str = reader.ReadLine();
                    if (str == null)
                    {
                        break;
                    }
                    s += str;
                }
                camera.CameraBackground = s;
               userControlCameraForm.CameraBackground = s;
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }


        private void Act(object type, Diagram.UI.Interfaces.ActionType actionType)
        {
            if (IsDisposed)
            {
                return;
            }
            actionType.EnableDisableButtons(startStopPauseButtons);
            if (actionType == Diagram.UI.Interfaces.ActionType.Start)
            {
                if (type != null)
                {
                    toolStripButtonPause.Enabled = false;
                    toolStripStart.Enabled = false;
                    toolStripStop.Enabled = false;
                }
            }
        }


        private void Start()
        {
            IProcess p = Motion6D.Portable.StaticExtensionMotion6DPortable.Animation;
            if (p == null)
            {
                return;
            }
            if (isPaused)
            {
                isPaused = false;
                Resume();
                return;
            }

            if (p is DataPerformer.UI.Interfaces.IAnimationParameters)
            {
                DataPerformer.UI.Interfaces.IAnimationParameters ap = p as
                   DataPerformer.UI.Interfaces.IAnimationParameters;
               // p.StartAnimation(null);
            }
            else
            {
                p.Start();
            }
            Act(null, Diagram.UI.Interfaces.ActionType.Start);
        }

        private void Stop()
        {
            IProcess p = Motion6D.Portable.StaticExtensionMotion6DPortable.Animation;
            if (p != null)
            {
                p.Terminate();
            }
            isPaused = false;
            Act(null, Diagram.UI.Interfaces.ActionType.Stop);
        }

        private void Resume()
        {
            IProcess p = Motion6D.Portable.StaticExtensionMotion6DPortable.Animation;
            if (p != null)
            {
                p.Resume();
            }
            Act(null, Diagram.UI.Interfaces.ActionType.Resume);
        }

        private void Pause()
        {
            isPaused = true;
            IProcess p = Motion6D.Portable.StaticExtensionMotion6DPortable.Animation;
            if (p != null)
            {
                p.Pause();
            }
            Act(null, Diagram.UI.Interfaces.ActionType.Pause);
        }

        #endregion

        #region Event Handlers

        private void toolStripTextBoxAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }


        private void toolStripStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void toolStripStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

 
        private void Brush_Click(object sender, EventArgs e)
        {
            LoadBrush();
        }

  
        private void toolStripButtonPause_Click(object sender, EventArgs e)
        {
            Pause();
        }

        #endregion

        private void FormCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            if (actionType != ActionType.Stop)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, "Form cannot be closed until end of thread");
                e.Cancel = true;
            }
        }

 
    }
}
