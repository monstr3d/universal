using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;
using NamedTree;
using SerializationInterface;

namespace DataSetService
{
    /// <summary>
    /// External data set provider
    /// </summary>
    [Serializable()]
    public class ExternalDataSetProvider : SavedDataProvider, IChildren<IAssociatedObject>
    {
        #region Fields

        /// <summary>
        /// Factory of data set
        /// </summary>
        IDataSetPoviderFactory factory;

        /// <summary>
        /// Type name of factory
        /// </summary>
        string factoryType;

        /// <summary>
        /// Url
        /// </summary>
        string url = "";

        IAssociatedObject[] children = new IAssociatedObject[1];

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor from type of child object
        /// </summary>
        /// <param name="factoryType">Type of factory</param>
        public ExternalDataSetProvider(string factoryType)
        {
            this.factoryType = factoryType;
            CreateFactory();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ExternalDataSetProvider(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            factoryType = info.GetString("Factory");
            url = info.GetString("Url");
            CreateFactory();
        }

        event Action<IAssociatedObject> IChildren<IAssociatedObject>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IAssociatedObject> IChildren<IAssociatedObject>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Factory", factoryType);
            info.AddValue("Url", url);
        }

        #endregion

        #region IChildrenObject Members
        IEnumerable<IAssociatedObject> IChildren<IAssociatedObject>.Children => children;



        #endregion

        #region Private Members

        /// <summary>
        /// Creates factory
        /// </summary>
        void CreateFactory()
        {
            Type t = Type.GetType(factoryType);
            if (t != null)
            {
                // Constructor of child object
                ConstructorInfo c = t.GetConstructor(new Type[0]);
                factory = c.Invoke(new object[0]) as IDataSetPoviderFactory;
                dataSet = factory.GetData(this.url);
                factory.Change += (string url) =>
                    {
                        if (this.url.Equals(url))
                        {
                            return;
                        }
                        this.url = url;
                        dataSet = factory.GetData(url);
                        change(dataSet);
                    };
                children[0] = factory as IAssociatedObject;
            }
        }

        void IChildren<IAssociatedObject>.AddChild(IAssociatedObject child)
        {
        }

        void IChildren<IAssociatedObject>.RemoveChild(IAssociatedObject child)
        {
        }

        #endregion
    }
}
