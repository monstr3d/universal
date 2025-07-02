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

namespace ImageTransformations.Labels
{
    /// <summary>
    /// Label of Web provider
    /// </summary>
    [Serializable()]
    public class WebProviderLabel : UserControlBaseLabel
    {
        #region Fields

        UserControlUrl uc;

        ExternalImage bmp;

        Form form;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public WebProviderLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected WebProviderLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        #endregion

        #region Overriden

        protected override UserControl Control
        {
            get
            {
                uc = new UserControlUrl();
                UpdateImage();
                return uc;
            }
        }

        protected override ICategoryObject Object
        {
            get
            {
                return bmp;
            }
            set
            {
                bmp = value.GetObject<ExternalImage>();
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
            if (type.Equals(typeof(ExternalImage)))
            {
                form = new FormWebImage(this);
                return;
            }
            form = new FormCtxExternalImage(this);
        }

        #endregion

        #region Own Members

        internal void UpdateImage()
        {
            if (uc == null)
            {
                return;
            }
            if (bmp == null)
            {
                return;
            }
            uc.Url = bmp.Url;
        }

        #endregion
    }
}
