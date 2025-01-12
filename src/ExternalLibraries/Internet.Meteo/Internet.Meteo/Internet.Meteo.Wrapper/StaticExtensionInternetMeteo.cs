using AssemblyService.Attributes;

namespace Internet.Meteo.Wrapper
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionInternetMeteo
    {

        #region Public Members

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr = null)
        {

        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionInternetMeteo()
        {
              new CodeCreators.CSCodeCreator();
        }

        #endregion

    }
}
