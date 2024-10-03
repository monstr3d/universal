using AssemblyService.Attributes;

namespace Chart.Library.Factory
{
    [InitAssembly]
    public static  class StaticExtensionChartLibraryFactory
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionChartLibraryFactory()
        {
            new CandleSeriesLibrary();
        }

        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

    }
}
