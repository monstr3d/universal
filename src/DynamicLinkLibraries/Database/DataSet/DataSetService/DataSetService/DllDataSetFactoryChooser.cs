using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

using AssemblyService;

namespace DataSetService
{
    /// <summary>
    /// Chooser of data set factory from dynamic link libraries
    /// </summary>
    public class DllDataSetFactoryChooser : DataSetFactoryChooser
    {
        #region Fields

        Dictionary<string, IDataSetFactory> factories = new Dictionary<string, IDataSetFactory>();

        string[] names;

        static DllDataSetFactoryChooser own;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">Path</param>
        public DllDataSetFactoryChooser(string path)
        {
            Initialize(path);
        }
 

        #endregion

        #region Overriden

        /// <summary>
        /// Names of factories
        /// </summary>
        public override string[] Names
        {
            get { return names; }
        }


        /// <summary>
        /// Gets facroty by name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The factory</returns>
        public override IDataSetFactory this[string name]
        {
            get { return factories[name]; }
        }

        #endregion

        #region Public

        /// <summary>
        /// Factory from base directory
        /// </summary>
        public static IDataSetFactoryChooser BaseDirectoryFactory
        {
            get
            {
                if (own == null)
                {
                    own = new DllDataSetFactoryChooser(AppDomain.CurrentDomain.BaseDirectory);
                }
                return own;
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Initialization of database drivers
        /// </summary>
        /// <param name="path">Path of drivers</param>
        void Initialize(string path)
        {
            // Gets all database drivers from this directory
            IEnumerable<IDataSetFactory> en = path.GetInterfaces<IDataSetFactory>();
            List<string> l = new List<string>();
            foreach (IDataSetFactory f in en)
            {
                factories[f.FactoryName] = f; // Dictinary of drivers
            }
            List<string> ln = new List<string>(factories.Keys);
            ln.Sort();
            names = ln.ToArray(); // Ordered names of drivers
        }

        #endregion
    }
}
