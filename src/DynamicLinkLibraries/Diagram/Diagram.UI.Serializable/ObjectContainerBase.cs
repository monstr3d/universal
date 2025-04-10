using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    /// <summary>
    /// Base conttainer of objects
    /// </summary>
    public abstract class ObjectContainerBase : Portable.ObjectContainer, ISerializable
    {
        #region Fields

        /// <summary>
        /// Desktop bytes
        /// </summary>
        byte[] Bytes
        {
            get;
            set;
        }
	
        /// <summary>
        /// Auxiliary field
        /// </summary>
        private Hashtable interr = null;
   
		/// <summary>
		/// Serialization binders
		/// </summary>
		static private SerializationBinder binder;
 
		#endregion

		#region Constructors

		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="desktop">The parent desktop</param>
		protected ObjectContainerBase(PureDesktop desktop) : base(desktop)
		{
		}

		/// <summary>
        /// Deserialization constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public ObjectContainerBase(SerializationInfo info, StreamingContext context) : base(new PureDesktopPeer())
		{
			Bytes = info.GetValue("Bytes", typeof(byte[])) as byte[];
            interr = info.GetValue("Interface", typeof(Hashtable)) as Hashtable;
            type = info.GetValue("Type", typeof(string)) as string;
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
			MemoryStream stream = new MemoryStream();
            SaveDesktop(stream);
			Bytes = stream.GetBuffer();
			info.AddValue("Bytes", Bytes);
            Hashtable interr = new Hashtable();
            foreach (string s in inter.Keys)
            {
                interr[s] = inter[s];
            }
            info.AddValue("Interface", interr);
			info.AddValue("Type", type);
		}

		#endregion

        #region Abstract Members

        /// <summary>
        /// Saves desktop
        /// </summary>
        /// <param name="stream">Stream to save</param>
        protected abstract void SaveDesktop(Stream stream);

        /// <summary>
        /// Loads desktop
        /// </summary>
        /// <param name="bytes">Soure bytes</param>
        /// <returns>Thrue in success and false otherwise</returns>
        protected abstract bool LoadDesktop(byte[] bytes);

        #endregion

        #region IPostSetArrow Members

        /// <summary>
        /// The post set arrow operation
        /// </summary>
		public override void PostSetArrow()
		{
		}

		#endregion

 
		#region Specific Members


        /// <summary>
        /// Loads itself
        /// </summary>
        /// <returns>True in success</returns>
        public override bool Load()
        {
            if (isLoaded)
            {
                return false;
            }
            isLoaded = true;
            if (desktop is PureDesktop pure)
            {
                pure.HasParent = true;
            }
            bool b = LoadDesktop(Bytes);
            LoadProtected();
            CreateInterface();
            return b;
        }

		/// <summary>
		/// The post load operation
		/// </summary>
		public override bool PostLoad()
		{
            if (!isLoaded)
            {
                return false;
            }
            if (isPostLoaded)
            {
                return true;
            }
            isPostLoaded = true;
			Bytes = null;
			GC.Collect();
            if (desktop is PureDesktop pure)
            {
                pure.PostLoad();
            }
            return true;
		}


		/// <summary>
		/// Adds a component
		/// </summary>
		/// <param name="c">The component to add</param>
		/// <param name="x">The x - coordinate</param>
		/// <param name="y">The y - coordinate</param>
		/// <param name="comment">The comment</param>
		public void Add(INamedComponent c, int x, int y, string comment)
		{
			string name = c.GetName(desktop);
			inter[name] = new object[]{x, y, comment};
		}

		/// <summary>
		/// Serialization binders
		/// </summary>
		public static SerializationBinder Binder
		{
			set
			{
				binder = value;
			}
		}

	
        /// <summary>
        /// Loads desktop
        /// </summary>
        /// <returns>Desktop</returns>
        public override IDesktop LoadDesktop()
        {
            (desktop as PureDesktopPeer).Load(Bytes);
            return desktop;
        }


        /// <summary>
        /// Post Load desktop
        /// </summary>
        /// <returns>True in success</returns>
        protected bool DesktopPostLoad()
        {
            desktop.PostLoad();
            return true;
        }


        #endregion

        #region Private Members

        void CreateInterface()
        {
            if (interr != null)
            {
                inter = new Dictionary<string, object>();
                foreach (string s in interr.Keys)
                {
                    inter[s] = interr[s];
                }
                interr = null;
            }
        }
        #endregion
    }
}
