using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    /// <summary>
    /// Replaces assembly
    /// </summary>
    public class ReplaceAssemblyCollection : IReplaceAssembly
    {
        #region Fields

        IReplaceAssembly[] replaces;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="replaces">Collection of replaces</param>
        public ReplaceAssemblyCollection(IReplaceAssembly[] replaces)
        {
            this.replaces = replaces;
        }

        #endregion

        #region IReplaceAssembly Members

        Assembly IReplaceAssembly.Replace(Assembly assembly)
        {
            foreach (IReplaceAssembly r in replaces)
            {
                Assembly ass = r.Replace(assembly);
                if (ass != null)
                {
                    return ass;
                }
            }
            return null;
        }

        #endregion

        #region Members

        /// <summary>
        /// Adss replace
        /// </summary>
        /// <param name="replace">Replace</param>
        public void Add(IReplaceAssembly replace)
        {
            List<IReplaceAssembly> l = new List<IReplaceAssembly>(replaces);
            l.Add(replace);
            replaces = l.ToArray();
        }

        #endregion
    }
}
