using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;


namespace DataPerformer
{
    /// <summary>
    /// Link to Switch
    /// </summary>
    [Serializable()]
    public class SwitchLink : ICategoryArrow, ISerializable, IDisposable
    {
        private FormulaDataConsumer target;
        private ISwitched source;
        /// <summary>
        /// Linked object
        /// </summary>
        protected object obj;
        int a;

        /// <summary>
        /// Default constructor
        /// </summary>
        public SwitchLink()
        {
            a = 0;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public SwitchLink(SerializationInfo info, StreamingContext context)
        {
            a = (int)info.GetValue("A", typeof(int));
        }
        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("A", a);
        }

        /*public XmlElement CreateXml(XmlDocument doc)
        {
            XmlElement el = doc.CreateElement("SwitchLink");
            return el;
        }*/



        /// <summary>
        /// Associated object
        /// </summary>
        public object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }


        /// <summary>
        /// The post remove operation
        /// </summary>
        void IDisposable.Dispose()
        {
            source.RemoveSwitch(this);
        }



        /// <summary>
        /// The source of this arrow
        /// </summary>
        public ICategoryObject Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                if (!(value is ISwitched))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                source = value as ISwitched;
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public ICategoryObject Target
        {
            get
            {
                return target;
            }
            set
            {
                if (source == null)
                {
                    throw new ErrorHandler.OwnException("Source object is missing");
                }
                if (source == value)
                {
                    throw new ErrorHandler.OwnException("Target of switch link should not concide with source");
                }
                if (!(value is FormulaDataConsumer))
                {
                    CategoryException.ThrowIllegalTargetException();
                }
                target = value as FormulaDataConsumer;
                source.AddSwitch(this);
            }
        }

        /// <summary>
        /// The "is monomorphism" sign
        /// </summary>
        public bool IsMonomorphism
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// The "is epimorphism" sign
        /// </summary>
        public bool IsEpimorphism
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The "is isomorphism" sign
        /// </summary>
        public bool IsIsomorphism
        {
            get
            {
                return false;
            }
        }

    }

    /// <summary>
    /// Switched object
    /// </summary>
    public interface ISwitched
    {
        /// <summary>
        /// Adds switch link
        /// </summary>
        /// <param name="link">Link to add</param>
        void AddSwitch(SwitchLink link);

        /// <summary>
        /// Removes switch link
        /// </summary>
        /// <param name="link">Link to remove</param>
        void RemoveSwitch(SwitchLink link);
    }


}
