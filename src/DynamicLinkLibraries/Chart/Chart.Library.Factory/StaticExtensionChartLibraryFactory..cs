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

        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

    }
}
