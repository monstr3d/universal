using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

using CategoryTheory;
using MathGraph;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;



namespace Diagram.UI
{
	/// <summary>
	/// Container of objects
	/// </summary>
	[Serializable()]
	public class ObjectContainer : ObjectContainerBase
    {

        #region Ctor

        		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="desktop">The parent desktop</param>
        public ObjectContainer(PureDesktopPeer desktop)
            : base(desktop)
        {
        }

		/// <summary>
        /// Deserialization constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public ObjectContainer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        #endregion

        /// <summary>
        /// Saves desktop
        /// </summary>
        /// <param name="stream">Stream to save</param>
        protected override void SaveDesktop(Stream stream)
        {
            (desktop as PureDesktopPeer).Save(stream);
        }

        /// <summary>
        /// Loads desktop
        /// </summary>
        /// <param name="bytes">Soure bytes</param>
        /// <returns>Thrue in success and false otherwise</returns>
        protected override bool LoadDesktop(byte[] bytes)
        {
            return (desktop as PureDesktopPeer).Load(bytes, false);
        }
    }

}
