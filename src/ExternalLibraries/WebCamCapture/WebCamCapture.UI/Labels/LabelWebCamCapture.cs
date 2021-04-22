using CategoryTheory;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCamCapture.UI.UserControls;

namespace WebCamCapture.UI.Labels
{
    [Serializable]
    class LabelWebCamCapture : UserControlBaseLabel
    {

        #region Fields

        SuperWebCamMeasurements camera;

        UserControlCamera userControl;

        #endregion

        internal LabelWebCamCapture(Type type) : this(type, "",
           Get(type))
        {

        }

        protected LabelWebCamCapture(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected LabelWebCamCapture(Type type, string kind, Image icon) : base(type, kind, icon)
        {

        }

        public override ICategoryObject Object
        {
            get
            {
                return camera;
            }
            set
            {
                if (!(value is SuperWebCamMeasurements))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                camera = value as SuperWebCamMeasurements;
                userControl.Camera = camera;
            }
        }

        protected override UserControl Control
        {
            get
            {
                if (userControl == null)
                {
                    userControl = new UserControlCamera();
                }
                return userControl;
            }
        }


        static Bitmap Get(Type type)
        {
            return type.Equals(typeof(WebCamMeasurements)) ?
                Properties.Resources.Photo.ToBitmap() : 
                Properties.Resources.PhotoEvent.ToBitmap();

        }
    }
}
