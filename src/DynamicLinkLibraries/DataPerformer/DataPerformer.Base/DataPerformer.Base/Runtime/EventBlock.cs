using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;

using Event.Interfaces;

namespace DataPerformer.Runtime
{
    /// <summary>
    /// Event block
    /// </summary>
    [Serializable()]
    public class EventBlock : CategoryObject, ISerializable, IEventBlock, IPostSetArrow
    {

        #region Fields

        string[] names = new string[0];

        List<IEvent> list = new List<IEvent>();

        #endregion
 
        #region Ctor

  		/// <summary>
		/// Default constructor
		/// </summary>
       public EventBlock()
       {
       }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
       protected EventBlock(SerializationInfo info, StreamingContext context)
       {
           names = info.GetValue("Names", typeof(string[])) as string[];
       }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Names", names, typeof(string[]));
        }

        #endregion

        #region IEventBlock Members

        bool IEventBlock.this[IEvent ev]
        {
            get 
            {
                return list.Contains(ev);
            }
        }

        string[] IEventBlock.Names
        {
            get
            {
                return names;
            }
            set
            {
                SetNames(value);
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            SetNames(names);
        }

        #endregion

        #region Private

        void SetNames(string[] names)
        {
            List<string> l = new List<string>();
            list.Clear();
            foreach (string name in names)
            {
                IEvent ev = this.GetRelativeObject<IEvent>(name);
                if (ev == null)
                {
                    continue;
                }
                list.Add(ev);
                l.Add(name);
            }
            this.names = names;
        }

        #endregion
    }
}
