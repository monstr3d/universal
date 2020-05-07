using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;

using DataPerformer;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;


namespace Motion6D
{
    /// <summary>
    /// Reference frame controlled by data
    /// </summary>
    [Serializable()]
    public class ReferenceFrameData : Portable.ReferenceFrameDataBase, ISerializable
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameData()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private ReferenceFrameData(SerializationInfo info, StreamingContext context)
        {
            try
            {
                parameters = info.GetValue("Parameters", typeof(List<string>)) as List<string>;
                isSerialized = true;
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }



        #endregion

        #region Specific Members
  
        /// <summary>
        /// Parameters
        /// </summary>
        new public List<string> Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                if (value.Count != 7)
                {
                    throw new Exception();
                }
                parameters = value;
                SetParameters();
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Parameters", parameters, typeof(List<string>));
        }

        #endregion
    }
}
