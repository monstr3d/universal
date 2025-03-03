using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using ErrorHandler;


namespace Diagram.UI
{
    /// <summary>
    /// Arrow label for serialization
    /// </summary>
    [Serializable()]
    public class PureArrowLabelPeer : PureArrowLabel, ISerializable, IArrowLabelHolder
    {
        #region Fields

        /// <summary>
        /// Associated label
        /// </summary>
        IArrowLabel label;

        /// <summary>
        /// Bytes
        /// </summary>
        byte[] bytes;

        #endregion

        #region Constructors

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="kind">The kind</param>
        /// <param name="type">The type</param>
        /// <param name="x">The x - coordinate</param>
        /// <param name="y">The y - coordinate</param>
        public PureArrowLabelPeer(string name, string kind, string type, int x, int y)
            : base(name, kind, type, x, y)
        {
            this.x = x;
            this.y = y;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public PureArrowLabelPeer(SerializationInfo info, StreamingContext context)
        {
            type= info.GetValue("Kind", typeof(string)) as string;
            kind = (string)info.GetValue("Type", typeof(string));
            name = (string)info.GetValue("Name", typeof(string));
            arrow = info.GetValue("Arrow", typeof(object)) as ICategoryArrow;
            sourceNumber = info.GetValue("SourceNumber", typeof(object));
            targetNumber = info.GetValue("TargetNumber", typeof(object));
            string t = arrow.GetType() + "";
            if (!t.Equals(type))
            {
                type = t;
            }
 
            try
            {
                bytes = PureDesktopPeer.LoadLabel(info);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            string t = Arrow.GetType().FullName;
            if (!t.Equals(type))
            {
                type = t;
            }
            info.AddValue("Kind", type);
            info.AddValue("Type", kind);
            info.AddValue("Name", name);
            info.AddValue("Arrow", arrow);
            info.AddValue("SourceNumber", sourceNumber);
            info.AddValue("TargetNumber", targetNumber);
            PureDesktopPeer.SaveLabel(label, bytes, info);
        }

        #endregion

        #region INamedComponent Members

        /// <summary>
        /// Gets component name relatively desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Relalive name</returns>
        public override string GetName(IDesktop desktop)
        {
            return PureObjectLabelPeer.GetName(this, desktop);
        }

        #endregion

        #region IArrowLabelHolder Members

        IArrowLabel IArrowLabelHolder.Label
        {
            get
            {
                return PureDesktopPeer.GetObject<IArrowLabel>(ref label, bytes);
            }
            set
            {
                label = value.GetSimpleObject<IArrowLabel>();
            }
        }

        #endregion
    }
}
