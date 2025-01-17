using System;
using System.Collections;
using System.Runtime.Serialization;

using Diagram.UI;
using ErrorHandler;


namespace Regression
{
    /// <summary>
    /// Regression based on the aliases 
    /// </summary>
    [Serializable()]
    public class AliasRegression : Portable.AliasRegression, ISerializable
    {

        #region Fields
        /// <summary>
        /// Comments
        /// </summary>
        private byte[] comments;


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AliasRegression()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public AliasRegression(SerializationInfo info, StreamingContext context)
        {
            aliasNames = (ArrayList)info.GetValue("AliasNames", typeof(ArrayList));
            measurementsNames = (Hashtable)info.GetValue("MeasurementsNames", typeof(Hashtable));
            selectionNames = (Hashtable)info.GetValue("SelectionNames", typeof(Hashtable));
            dispersions = (double[])info.GetValue("Dispersions", typeof(double[]));
            delta = (double[])info.GetValue("Delta", typeof(double[]));
            try
            {
                standardDeviation = info.GetDouble("StandardDeviation");
            }
            catch (Exception ex)
            {
                ex.ShowError(-1);
            }
            try
            {
                comments = (byte[])info.GetValue("Comments", typeof(byte[]));
            }
            catch (Exception exc)
            {
                exc.ShowError(-1);
            }
            try
            {
                Coefficient = info.GetDouble("Coefficient");
            }
            catch (Exception exc)
            {
                exc.ShowError(-1);
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AliasNames", aliasNames);
            info.AddValue("MeasurementsNames", measurementsNames);
            info.AddValue("SelectionNames", selectionNames);
            info.AddValue("Dispersions", dispersions);
            info.AddValue("Delta", delta);
            info.AddValue("StandardDeviation", standardDeviation);
            if (comments == null)
            {
                comments = new byte[0];
            }
            info.AddValue("Comments", comments);
            info.AddValue("Coefficient", Coefficient);
        }

        #endregion
    }
}