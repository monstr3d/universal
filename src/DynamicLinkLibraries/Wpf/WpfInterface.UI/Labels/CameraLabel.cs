using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;



using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;


using WpfInterface.CameraInterface;
using WpfInterface.UI.UserControls;
using WpfInterface.UI;

namespace WpfInterface.UI.Labels
{
    [Serializable()]
    public class CameraLabel : UserControlBaseLabel, IStartStop
    {

        #region Fields

        WpfCamera camera;

        new UserControlCameraForm control;

        private Forms.FormCamera form = null;

        private Diagram.UI.Interfaces.ActionType actionType = ActionType.Stop;

 
        #endregion

        #region Ctor

        public CameraLabel()
            : base(typeof(WpfCamera), "", ResourceImage.Camera)
        {
        }

        protected CameraLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
       

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, Diagram.UI.Interfaces.ActionType actionType)
        {
            this.actionType = actionType;
            if (form == null)
            {
                return;
            }
            if (form.IsDisposed)
            {
                return;
            }
            IStartStop ss = form;
            ss.Action(type, actionType);
        }

        #endregion
 
        #region Overriden Members


        protected override UserControl Control
        {
            get 
            {
                control = new UserControlCameraForm();
                if (camera != null)
                {
                    control.CameraBackground = camera.CameraBackground;
                }
                
                return control;
            }
        }

        public override ICategoryObject Object
        {
            get
            {
                return camera;
            }
            set
            {
                camera = value as WpfCamera;
                control.Camera = camera;
            }
        }

        public override void CreateForm()
        {
            if (actionType != ActionType.Stop)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, "Form cannot be opened until end of thread");
                return;
            }
            control.Control.Content = null;
            form = new Forms.FormCamera(this, camera);   
        }

        public override object Form
        {
            get
            {
                return form;
            }
        }

        #endregion


    }
}
