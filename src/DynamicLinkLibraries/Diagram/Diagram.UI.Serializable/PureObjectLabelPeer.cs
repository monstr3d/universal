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
    /// Object label for serialization
    /// </summary>
    [Serializable()]
    public class PureObjectLabelPeer : PureObjectLabel, ISerializable, IObjectLabelHolder
    {
        #region Fields

        /// <summary>
        /// Associated label
        /// </summary>
        IObjectLabel label;

        /// <summary>
        /// Bytes of label
        /// </summary>
        byte[] bytes;

        #endregion

        #region Constuctors

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="kind">The kind</param>
        /// <param name="type">The type</param>
        /// <param name="x">The x - coordinate</param>
        /// <param name="y">The y - coordinate</param>
        public PureObjectLabelPeer(string name, string kind, string type, int x, int y)
            : base(name, kind, type, x, y)
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PureObjectLabelPeer(SerializationInfo info, StreamingContext context)
        {
            type = info.GetValue("Kind", typeof(string)) as string;
            kind = (string)info.GetValue("Type", typeof(string));
            name = (string)info.GetValue("Name", typeof(string));
            x = (int)info.GetValue("X", typeof(int));
            y = (int)info.GetValue("Y", typeof(int));
            obj = info.GetValue("Object", typeof(object)) as ICategoryObject;
            string t = obj.GetType() + "";
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
            string t = Object.GetType().FullName;
            if (!t.Equals(type))
            {
                type = t;
            }
            info.AddValue("Kind", type);
            info.AddValue("Type", kind);
            info.AddValue("Name", name);
            info.AddValue("X", x);
            info.AddValue("Y", y);
            info.AddValue("Object", obj);
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
            return GetName(this, desktop);
        }

        #endregion

        #region ILabelHolder Members

        IObjectLabel IObjectLabelHolder.Label
        {
            get
            {
                return PureDesktopPeer.GetObject<IObjectLabel>(ref label, bytes);
            }
            set
            {
                label = value.GetSimpleObject<IObjectLabel>();
            }
        }

        #endregion

        #region Specific members

  
        #endregion


    }
}