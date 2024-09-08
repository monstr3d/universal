using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Collection of loaders
    /// </summary>
    public class LogListLoaderCollection : ILogLoader
    {

        #region Fields

        List<ILogLoader> loaders = new List<ILogLoader>();

        private event Action<string> postLoad = (string url) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loaders"></param>
        public LogListLoaderCollection(IEnumerable<ILogLoader> loaders)
        {
            this.loaders.AddRange(loaders);
        }

        #endregion

        #region  ILogLoader  Members

        object ILogLoader.Load(string url, uint begin, uint end)
        {
            foreach (ILogLoader loader in loaders)
            {
                object reader = loader.Load(url, begin, end);
                if (reader != null)
                {
                    return reader;
                }
            }
            return null;
        }


        #endregion

        #region Private Members



        #endregion

        #region Public Members

        /// <summary>
        /// Adds a loader
        /// </summary>
        /// <param name="loader">The loder for add</param>
        public void Add(ILogLoader loader)
        {
            loaders.Add(loader);
        }

    
        /// <summary>
        /// Post load event
        /// </summary>
        public event Action<string> PostLoad
        {
            add { postLoad += value; }
            remove { postLoad -= value; }
        }


        #endregion


    }
}
