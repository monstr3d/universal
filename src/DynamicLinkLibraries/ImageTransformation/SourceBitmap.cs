using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI;


using DataPerformer;
using DataPerformer.Interfaces;


using BitmapConsumer;

namespace ImageTransformations
{
    /// <summary>
    /// Stored bitmap
    /// </summary>
    [Serializable()]
    public class SourceBitmap : AbstractBitmap
    {

        #region Fields
   
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SourceBitmap()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public SourceBitmap(SerializationInfo info, StreamingContext context)
        {
            try
            {
                bitmap = (Bitmap)info.GetValue("Bitmap", typeof(Bitmap));
            }
            catch (Exception ex)
            {
                ex.ShowError(100);
            }
            comments = (ArrayList)info.GetValue("Comments", typeof(ArrayList));
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
            info.AddValue("Bitmap", bitmap);
            if (comments != null)
            {
                info.AddValue("Comments", comments);
            }
        }

        #endregion

        public override Image Image
        {
            get
            {
                return bitmap;
            }
            set
            {

            }
        }

    }
}
