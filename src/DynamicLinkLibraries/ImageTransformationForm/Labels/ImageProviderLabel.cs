using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;


using System.Windows.Forms;

using CategoryTheory;


using Diagram.UI.Labels;

using ImageTransformations.UserControls;
using ImageTransformations.Forms;

using GraphicsControls;
using Diagram.UI.Interfaces;
using Diagram.UI;

namespace ImageTransformations.Labels
{
    [Serializable()]
    public class ImageProviderLabel : UserControlBaseLabel
    {
        #region Fields

        UserControlImage uc;

        AbstractBitmap bmp;

        Form form;

        bool isScaled;

        #endregion

        #region Ctor

        public ImageProviderLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        protected ImageProviderLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        #endregion

        #region Overriden
        
        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("IsScaled", isScaled);
        }
  
        protected override UserControl Control
        {
            get 
            { 
                uc = new UserControlImage();
                uc.Dock = DockStyle.Fill;
                uc.IsScaled = isScaled;
                uc.ChangeScale += (bool b) => { isScaled = b; };
                UpdateImage();
                return uc;
            }
        }

        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            try
            {
                isScaled = info.GetBoolean("IsScaled");
            }
            catch (Exception)
            {
            }
        }

       

        public override ICategoryObject Object
        {
            get
            {
                return bmp;
            }
            set
            {
                bmp = value.GetObject<AbstractBitmap>();
                UpdateImage();
            }
        }

        public override object Form
        {
            get
            {
                return form;
            }
        }

        public override void CreateForm()
        {
            if (bmp is IPropertiesEditor)
            {
                IPropertiesEditor pe = bmp as IPropertiesEditor;
                form = (pe.Editor as object[])[0] as Form;
                return;
            }
            form = new FormSourceBitmap(this);
        }

        #endregion

        #region Own Members

        public bool IsScaled
        {
            get
            {
                return isScaled;
            }
            set
            {
                if (isScaled == value)
                {
                    return;
                }
                isScaled = value;
                UpdateImage();
            }

        }


        internal void UpdateImage()
        {
            if (bmp == null)
            {
                return;
            }
            Image im = bmp.Image;
            if (im == null)
            {
                return;
            }
            if (uc == null)
            {
                return;
            }
            uc.IsScaled = isScaled;
            uc.Image = im;
        }

        #endregion
    }
}
