using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;



using Diagram.UI.Aliases;

using SerializationInterface;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;
using Motion6D;

namespace Motion6D
{
    /// <summary>
    /// Facet phisical field
    /// </summary>
    [Serializable()]
    public class FacetPhysicalField3D : Portable.FacetPhysicalField3D, ISerializable
    {

        #region Fields

        private IFacet facets;

        //private double tempPos;

        private Dictionary<int, string> aliases = new Dictionary<int, string>();

        private Dictionary<int, AliasName> parameters = new Dictionary<int, AliasName>();

        string areaString = "";

        string normalString = "";

        private Func<object, object, object>[] adds = null;

        private AliasName area;

        private AliasName normal;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FacetPhysicalField3D()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FacetPhysicalField3D(SerializationInfo info, StreamingContext context)
        {
            areaString = info.Deserialize<string>("Area");
            normalString = info.Deserialize<string>("Normal");
            aliases = info.Deserialize<Dictionary<int, string>>("Additional");
        }



        #endregion

        #region Overriden Members


        /// <summary>
        /// Implementation of serialization
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // base.GetObjectData(info, context);
            info.Serialize<string>("Area", areaString);
            info.Serialize<string>("Normal", normalString);
            info.Serialize<Dictionary<int, string>>("Additional", aliases);
        }

        #endregion

    }
}
