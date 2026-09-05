using System.Reflection;

using DataSetService.Pure.Interfaces;

using NamedTree.Interfaces;

namespace DataSetService.Pure
{
    /// <summary>
    /// External data set provider
    /// </summary>
    public class ExternalDataSetProvider : SavedDataProvider, IChildren<IAssociatedObject>
    {
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        protected ExternalDataSetProvider() 
        { }

        #endregion

        #region Fields

        /// <summary>
        /// Factory of data set
        /// </summary>
        protected IDataSetPoviderFactory factory;

        /// <summary>
        /// Type name of factory
        /// </summary>
        protected string factoryType;

        /// <summary>
        /// Url
        /// </summary>
        protected string url = "";

        protected IAssociatedObject[] children = new IAssociatedObject[1];

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


        #region IChildrenObject Members
        IEnumerable<IAssociatedObject> IChildren<IAssociatedObject>.Children => children;



        #endregion

        #region Private Members

        /// <summary>
        /// Creates factory
        /// </summary>
        protected void CreateFactory()
        {
            Type t = Type.GetType(factoryType);
            if (t != null)
            {
                // Constructor of child object
                ConstructorInfo c = t.GetConstructor([]);
                factory = c.Invoke([]) as IDataSetPoviderFactory;
                dataSet = factory.GetData(url);
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
