using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer.Event.Portable.Objects.BufferedData;
using DataPerformer.UI.BufferedData.UserControls;

namespace DataPerformer.UI.BufferedData.Labels
{
    /// <summary>
    /// Label of buffer
    /// </summary>
    [Serializable()]
    public class BufferReadWriteLabel : UserControlBaseLabel, IPostSet
    {

        #region Fields


        UserControlBufferReadWrite uc;

        BufferReadWrite buffer;


        Form form;

        internal Dictionary<string, Size> sizes = new Dictionary<string, Size>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BufferReadWriteLabel()
                : base(typeof(EventRelated.BufferedData.BufferReadWrite), "", 
                      ResourceImage.DataObjectIcon.ToBitmap())
        {
 
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected BufferReadWriteLabel(SerializationInfo info, StreamingContext context)
                : base(info, context)
        {

        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Sizes", sizes, typeof(Dictionary<string, Size>));
        }

        #endregion

        #region IObjectLabel Members

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return buffer;
            }
            set
            {
                if (!(value is BufferReadWrite))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                buffer = value as BufferReadWrite;
                value.Object = this;
                uc.Buffer = buffer;
            }
        }

        #endregion

        #region IPostSet Members

        void IPostSet.Post()
        {

        }

        #endregion

        #region Overriden Members

        public override void CreateForm()
        {
            form = new FormBufferReadWrite(this);
        }


        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {

        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get
            {
                return form;
            }
        }

        /// <summary>
        /// Load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            try
            {
                sizes = info.GetValue("Sizes", typeof(Dictionary<string, Size>)) 
                    as Dictionary<string, Size>;
           }
            catch
            {

            }

        }

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                uc = new UserControlBufferReadWrite();
                return uc;
            }
        }

        #endregion

        #region Specific Members
 

        #endregion

    }
}