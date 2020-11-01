using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Motion6D;
using Motion6D.UI.UserControls;

namespace Motion6D.UI.Labels
{
    /// <summary>
    /// UI Label of "ReferenceFrameData" object
    /// </summary>
    [Serializable()]
    public class ReferenceFrameDataLabel : UserControlBaseLabel
    {
        #region Fields

        /// <summary>
        /// User control of frame data
        /// </summary>
        protected UserControlFrameData userControlFrameData;

        Portable.ReferenceFrameDataBase frame;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameDataLabel()
            : this(typeof(ReferenceFrameData), "", ResourceImage.DataFrame.ToBitmap())
        {

        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public ReferenceFrameDataLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ReferenceFrameDataLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        #region Overriden


        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                userControlFrameData = new UserControlFrameData();
                return userControlFrameData;
            }
        }


        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return frame;
            }
            set
            {
                if (!(value is Portable.ReferenceFrameDataBase))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                frame = value as Portable.ReferenceFrameDataBase;
                userControlFrameData.Frame = frame;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            userControlFrameData.Fill();
        }

        /// <summary>
        /// Label form
        /// </summary>
        public override object Form
        {
            get
            {
                return new Forms.FormFrameData(this);
            }
        }

        #endregion

    }
}