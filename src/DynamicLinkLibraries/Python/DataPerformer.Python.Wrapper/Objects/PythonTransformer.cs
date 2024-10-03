using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Python.Wrapper.Objects
{
    /// <summary>
    /// Python transformer
    /// </summary>
    [Serializable]
    public class PythonTransformer : Python.Objects.PythonTransformer, ISerializable
    {
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public PythonTransformer() : base()
        {

        }

        private PythonTransformer(SerializationInfo info, StreamingContext context) : this()
        {
            Code = info.GetString("Code");
            Inputs = info.GetValue("Inputs", typeof(Dictionary<string, string>))
                as Dictionary<string, string>;
            Outputs = info.GetValue("Outputs", typeof(Dictionary<string, object[]>))
                as Dictionary<string, object[]>;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Code", Code);
            info.AddValue("Inputs", Inputs, typeof(Dictionary<string, string>));
            info.AddValue("Outputs", Outputs, typeof(Dictionary<string, object[]>));
        }

        #endregion

    }
}
