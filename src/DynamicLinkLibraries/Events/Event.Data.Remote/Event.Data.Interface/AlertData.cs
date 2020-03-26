using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

/// <summary>
/// Alert data
/// </summary>
[DataContract]
[KnownType(typeof(object[]))]
public class AlertData
{
    /// <summary>
    /// Data
    /// </summary>
    [DataMember]
    public object[] Data { get; set; }
}
