using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Aliases;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;
using PhysicalField.Interfaces;


namespace Motion6D
{
    /// <summary>
    /// Consumer of 3D physical field
    /// </summary>
    [Serializable()]
    public class FieldConsumer3D : Portable.FieldConsumer3D, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="facet"></param>
        public FieldConsumer3D(IFacet facet) :
            base(facet)
        {
            
        }

        /// <summary>
        /// Deserialisation constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected FieldConsumer3D(SerializationInfo info, StreamingContext context) :
            base(null)
        {
            Init();
            intAliases = info.GetValue("IntAliases", typeof(Dictionary<int, string>)) as Dictionary<int, string>;
            extAliases = info.GetValue("ExtAliases", typeof(Dictionary<string, Dictionary<int, string>>)) as
                Dictionary<string, Dictionary<int, string>>;
            outcoming = info.GetValue("Outcoming", typeof(List<string>)) as List<string>;
            colors = info.GetValue("Colors", typeof(List<string>)) as List<string>;
            colored = (bool)info.GetValue("Colored", typeof(bool));
            proportional = (bool)info.GetValue("Proportional", typeof(bool));
            rainbowScale = (bool)info.GetValue("RainbowScale", typeof(bool));
            enabled = (bool)info.GetValue("Enabled", typeof(bool));
        }
        

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IntAliases", intAliases, typeof(Dictionary<int, string>));
            info.AddValue("ExtAliases", extAliases, typeof(Dictionary<string, Dictionary<int, string>>));
            info.AddValue("Outcoming", outcoming, typeof(List<string>));
            info.AddValue("Colors", colors, typeof(List<string>));
            info.AddValue("Colored", colored, typeof(bool));
            info.AddValue("Proportional", proportional, typeof(bool));
            info.AddValue("RainbowScale", rainbowScale, typeof(bool));
            info.AddValue("Enabled", enabled, typeof(bool));
        }

        #endregion
    }
}
