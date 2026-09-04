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

        private static string coreAssName = "";

        private static string[] old = ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"];


        static BinderCollection()
        {
            coreAssName = typeof(List<string>).Assembly.FullName;
        }

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
            var an = Trasform(assemblyName);
            var tn = Trasform(typeName);
            var fullName = string.Format("{0}, {1}", tn, an);
            try
            {
                Type t = Type.GetType(fullName);
                if (t != null)
                {
                    var inter = new List<Type>(t.GetInterfaces());
                    if (!inter.Contains(typeof(ISerializable)))
                    {
                    }
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
                    Type t = binder.BindToType(an, tn);
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

        #region Private Members

        string Trasform(string assemblyName)
        {
            var s = assemblyName;
            foreach (var o in old)
            {
                if (s.Contains(o))
                {
                    s = s.Replace(o, coreAssName);
                }
            }
            return s;
            
        }

        #endregion

    }
}
