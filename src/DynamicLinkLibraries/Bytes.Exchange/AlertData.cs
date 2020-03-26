using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Bytes.Exchange
{
    [DataContract]
    [KnownType(typeof(byte[]))]
    public class AlertData
    {
        /// <summary>
        /// Data
        /// </summary>
        [DataMember]
        public byte[] Data { get; set; }
    }
}
