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
        /// Inits itself
        /// </summary>
        static public void Init()
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
