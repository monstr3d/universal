using DataPerformer.Portable.Filters;
using Diagram.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Base.Filters
{
    [Serializable()]
    public class FilterWrapper : Portable.FilterWrapper, ISerializable
    {
        public FilterWrapper(int kind)
            : base(kind) { }

        private FilterWrapper(SerializationInfo info, StreamingContext context) : base(true)
        {
            kind = info.GetInt32("Kind");
            Input = info.GetString("Input");
            SetFilter();
            filter.Count = info.GetInt32("Count");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Kind", kind);
            info.AddValue("Count", filter.Count);
            info.AddValue("Input", Input);
        }
    }
}