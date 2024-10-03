using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using BaseTypes;

using SerializationInterface;

namespace DataPerformer.Objects
{

    /// <summary>
    /// Manual input
    /// </summary>
    [Serializable]
    public class ManualInput : DataPerformer.Portable.Objects.ManualInput, ISerializable
    {


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManualInput()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ManualInput(SerializationInfo info, StreamingContext context)
        {
            Types = info.Deserialize<List<Tuple<string, object>>>("Types");
            initial = info.Deserialize<object[]>("Initial");
            data = new object[initial.Length];
            for (int i = 0; i < initial.Length; i++)
            {
                if (initial[i] == null)
                {
                    initial[i] = types[i].Item2.GetDefaultValue();
                }
            }
            Array.Copy(initial, data, data.Length);
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<List<Tuple<string, object>>>("Types", types);
            info.Serialize<object[]>("Initial", initial);
        }

        #endregion


    }
}
