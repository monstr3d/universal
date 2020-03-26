using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace SerializationInterface
{
    /// <summary>
    /// Collection of binders
    /// </summary>
    public class BinderCollection : SerializationBinder
    {
        #region Fields

        /// <summary>
        /// Binders
        /// </summary>
        private SerializationBinder[] binders;

        #endregion

        #region Ctor


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="binders">Binders</param>
        public BinderCollection(SerializationBinder[] binders)
        {
            this.binders = binders;
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Binds to type
        /// </summary>
        /// <param name="assemblyName">Assembly name</param>
        /// <param name="typeName">Type name</param>
        /// <returns>Type</returns>
        public override Type BindToType(string assemblyName, string typeName)
        {
            try
            {
                Type t = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
                if (t != null)
                {
                    return t;
                }
            }
            catch (Exception)
            {

            }
            foreach (SerializationBinder binder in binders)
            {
                try
                {
                    Type t = binder.BindToType(assemblyName, typeName);
                    if (t != null)
                    {
                        return t;
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            throw new TypeLoadException(assemblyName + " " + typeName);
        }

        #endregion


        #region Public Members

        /// <summary>
        /// Adds a binder
        /// </summary>
        /// <param name="binder">The binder</param>
        public void Add(SerializationBinder binder)
        {
            List<SerializationBinder> l = new List<SerializationBinder>(binders);
            l.Add(binder);
            binders = l.ToArray();
        }

        #endregion

    }
}
