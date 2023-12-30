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
        public FilterWrapper(string kind)
            : base(kind) { }

        private FilterWrapper(SerializationInfo info, StreamingContext context) : base(true)
        {
            kind = info.GetString("Kind");
            Input = info.GetString("Input");
            SetFilter();
            filter.Count = info.GetInt32("Count");
            if (filter is Donchian)
            {
                (filter as Donchian).Max = info.GetBoolean("Max");
            }

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Kind", kind);
            info.AddValue("Count", filter.Count);
            info.AddValue("Input", Input);
            if (filter is Donchian)
            {
                info.AddValue("Max", (filter as Donchian).Max);
            }
        }
    }
}