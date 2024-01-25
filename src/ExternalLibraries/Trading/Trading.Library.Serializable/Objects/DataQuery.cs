using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trading.Library.Serializable.Objects
{
    [Serializable]
    public class DataQuery : Library.Objects.DataQuery, ISerializable
    {

        private DataQuery(SerializationInfo info, StreamingContext context) 
        {
            Period = info.GetString("Period");
            Begin = (DateTime)info.GetValue("Begin", typeof(DateTime));
            End = (DateTime)info.GetValue("End", typeof(DateTime));
            Guid = (Guid)info.GetValue("Guid", typeof(Guid));
        }
        public DataQuery() { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Period", Period);
            info.AddValue("Begin", Begin, typeof(DateTime));
            info.AddValue("End", End, typeof(DateTime));
            info.AddValue("Guid", Guid, typeof(Guid));
        }
    }
}
