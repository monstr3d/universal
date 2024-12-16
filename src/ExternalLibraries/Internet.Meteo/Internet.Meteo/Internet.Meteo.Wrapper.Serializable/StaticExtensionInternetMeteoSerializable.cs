using AssemblyService.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet.Meteo.Wrapper.Serializable
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static  class StaticExtensionInternetMeteoSerializable
    {

        #region Public Members

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionInternetMeteoSerializable()
        {
            new CodeCreators.CSCodeCreator();
        }

        #endregion

    }
}
