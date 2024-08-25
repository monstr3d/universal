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
        /// Inits itself
        /// </summary>
        public static void Init()
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
