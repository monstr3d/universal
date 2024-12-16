using AssemblyService.Attributes;

namespace Internet.Meteo.UI
{

    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionInternetMeteoUI
    {

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionInternetMeteoUI()
        {
            new UIFactory();
        }
    }
}
