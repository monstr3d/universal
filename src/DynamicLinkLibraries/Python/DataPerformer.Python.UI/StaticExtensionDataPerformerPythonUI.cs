using AssemblyService.Attributes;
using DataPerformer.Python.UI.Factory;

namespace DataPerformer.Python.UI
{
    /// <summary>
    /// Extension utilites
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerPythonUI
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
        static StaticExtensionDataPerformerPythonUI()
        {
            new UIFactory();
        }

    }
}
