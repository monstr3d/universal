using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;

using SerializationInterface;

using Event.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;


namespace Event.Basic.Data.Events
{
    /// <summary>
    /// Imported event with reading data
    /// </summary>
    [Serializable()]
    public class ImportedEventReader : Portable.Events.ImportedEventReader, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of imported object</param>
        public ImportedEventReader(string type) : base(type)
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ImportedEventReader(SerializationInfo info, StreamingContext context) : base("")
        {
            eventReader = info.Deserialize<IEventReader>("EventReader");
            try
            {
                eventName = info.GetString("EventName");
            }
            catch (Exception)
            {

            }
            PostConstructor();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<IEventReader>("EventReader", eventReader);
            info.AddValue("EventName", eventName);
        }

        #endregion

    }
}
