using AssemblyService.Attributes;

namespace Diagram.UI.TypeScript
{
    [InitAssembly]
    public static class StaticrExtensionDiagramTypeScript
    {
        static StaticrExtensionDiagramTypeScript()
        {
            new ObjectContainerClassCodeCreator();
            new DesktopCodeCreator();
        }

        /// <summary>
        /// Initializes itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

    }
}
